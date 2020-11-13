using System;
using System.IO;
using System.Windows.Forms;

namespace ArenaFighterEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextReader characterFile = new StreamReader(openFileDialog1.FileName);
                int weapon, armor;
                playerName.Text = characterFile.ReadLine();
                playerSex.Text = characterFile.ReadLine();
                playerLevel.Text = characterFile.ReadLine();
                playerExp.Text = characterFile.ReadLine();
                playerGold.Text = characterFile.ReadLine();
                playerHealth.Text = characterFile.ReadLine();
                playerMaxHealth.Text = characterFile.ReadLine();
                playerStrength.Text = characterFile.ReadLine();
                playerAgility.Text = characterFile.ReadLine();
                weapon = Convert.ToInt16(characterFile.ReadLine()) - 1;
                armor = Convert.ToInt16(characterFile.ReadLine()) - 1;
                playerPotions.Text = characterFile.ReadLine();
                characterFile.Close();
                if ((weapon > 11) || (weapon < 0))
                {
                    playerWeapon.SelectedIndex = 0;
                }
                else
                {
                    playerWeapon.SelectedIndex = weapon;
                }
                if ((armor > 11) || (armor < 0))
                {
                    playerArmor.SelectedIndex = 0;
                }
                else
                {
                    playerArmor.SelectedIndex = armor;
                }
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = playerName.Text + ".dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextWriter characterFile = new StreamWriter(saveFileDialog1.FileName);
                characterFile.WriteLine(playerName.Text);
                characterFile.WriteLine(playerSex.Text);
                characterFile.WriteLine(playerLevel.Text);
                characterFile.WriteLine(playerExp.Text);
                characterFile.WriteLine(playerGold.Text);
                characterFile.WriteLine(playerHealth.Text);
                characterFile.WriteLine(playerMaxHealth.Text);
                characterFile.WriteLine(playerStrength.Text);
                characterFile.WriteLine(playerAgility.Text);
                characterFile.WriteLine(playerWeapon.SelectedIndex + 1);
                characterFile.WriteLine(playerArmor.SelectedIndex + 1);
                characterFile.WriteLine(playerPotions.Text);
                characterFile.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
        }
    }
}
