    public partial class randomNumberForm : Form
    {
        Random ranNum = new Random();
        int userGuess = 0;
        int numberOfGuesses = 0;
        int? randomNumber;
        public randomNumberForm()
        {
            InitializeComponent();
        }
        public void randomNumberForm_Load(object sender, EventArgs e)
        {
        }
        public void guessButton_Click(object sender, EventArgs e)
        {
            if (!randomNumber.HasValue) // first time run 
                randomNumber = ranNum.Next(101) + 1;
            if (int.TryParse(inputTextBox.Text, out userGuess))
            {
                if (userGuess < randomNumber)
                {
                    answerLabel.Text = "Too low, try again.";
                    numberOfGuesses++;
                    guessLabel.Text = numberOfGuesses.ToString();
                }
                else if (userGuess > randomNumber)
                {
                    answerLabel.Text = "Too high, try again.";
                    numberOfGuesses++;
                    guessLabel.Text = numberOfGuesses.ToString();
                }
                else if (userGuess == randomNumber)
                {
                    answerLabel.Text = "You guessed the right number!";
                    numberOfGuesses++;
                    guessLabel.Text = numberOfGuesses.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid integer.");
            }
        }
