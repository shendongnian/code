    namespace Guessing_Game
    {
       public partial class Form1 : Form
       {
            private static int randomNumber;
            private const int rangeNumberMin = 1;
            private const int rangeNumberMax = 10;
            private const int maxGuesses = 5;
            public Form1()
            {
                InitializeComponent();
                guessesTaken = 0;
                randomNumber = GenerateNumber(rangeNumberMin, rangeNumberMax);
            }
            private int GenerateNumber(int min,int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
            private void btnOk_Click(object sender, EventArgs e)
            {
                int yourNumber = 0;
                if (Int32.TryParse(textBox1.Text.Trim(), out yourNumber) &&
                   yourNumber>= rangeNumberMin && yourNumber<=rangeNumberMax)
                {
                    
                    listBox1.Items.Add(yourNumber);
                    if (yourNumber > randomNumber)
                    {
                        listBox2.Items.Add("No the Magic Number is lower than your number");
                    }
                    else if (yourNumber < randomNumber)
                    {
                        listBox2.Items.Add("No, the Magic Number is higher than your number");
                    }
                    else
                    {
                        listBox2.Items.Add("You guessed the Magic Number!");
                        btnRestart.Enabled = true;
                    }
                    //Will stop on the 5th guess, but guards the case that there were more than 5 guesses
                    if(listBox1.Items.Count >= maxGuesses)
                    { 
                        listBox2.Items.Add("You are out of guesses!");
                        textBox1.Enabled = false;
                        btnOk.Enable = false;
                        btnRestart.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a number between " + rangeNumberMin + " to " + rangeNumberMax);
                }
            }
            private void btnRestart_Click(object sender, EventArgs e)
            {
                listBox2.Items.Clear();
                listBox1.Items.Clear();
                textBox1.Text = null;
                guessesTaken = 0;
                randomNumber = GenerateNumber(rangeNumberMin, rangeNumberMax);
                btnRestart.Enabled = false;
                textBox1.Enabled = true;
                btnOk.Enable = true;
            }
        }
    }
