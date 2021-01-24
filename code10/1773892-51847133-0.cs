    public partial class Form1 : Form
    {
        private Button btnSubmit;
        private Label lblGuess;
        private TextBox txtGuess;
        private Label lblWord;
        private Label lblGuessedLetters;
        private ListBox lstGuessedLetters;
        private readonly BindingList<char> guesses = new BindingList<char>();
        private const string WordToGuess = "StackOverflow";
        private const int controlHeight = 20;
        private const int controlWidth = 200;
        private const int controlPadding = 10;
        public Form1()
        {
            InitializeComponent();
            lblWord = new Label
            {
                Left = controlPadding,
                Top = controlPadding,
                Height = controlHeight,
                Width = controlWidth,
                Text = new string('_', WordToGuess.Length)
            };
            Controls.Add(lblWord);
            lblGuessedLetters = new Label
            {
                Left = controlPadding,
                Top = lblWord.Bottom + controlPadding,
                Height = controlHeight,
                Width = controlWidth,
                Text = "Guessed Letters:"
            };
            Controls.Add(lblGuessedLetters);
            lstGuessedLetters = new ListBox
            {
                Left = controlPadding,
                Top = lblGuessedLetters.Bottom + controlPadding,
                Height = controlHeight * 5,
                Width = controlWidth,
                Enabled = false,
                DataSource = guesses,
                SelectionMode = SelectionMode.None
            };
            Controls.Add(lstGuessedLetters);
            lblGuess = new Label
            {
                Left = controlPadding,
                Top = lstGuessedLetters.Bottom + controlPadding,
                Height = controlHeight,
                Width = controlWidth,
                Text = "Enter your guess below"
            };
            Controls.Add(lblGuess);
            txtGuess = new TextBox
            {
                Left = controlPadding,
                Top = lblGuess.Bottom + controlPadding,
                Height = controlHeight,
                Width = controlWidth
            };
            Controls.Add(txtGuess);
            btnSubmit = new Button
            {
                Left = controlPadding,
                Top = txtGuess.Bottom + controlPadding,
                Height = controlHeight,
                Width = controlWidth,
                Text = "Submit Guess"
            };
            btnSubmit.Click += BtnSubmit_Click;
            AcceptButton = btnSubmit; // Make this button default - just press Enter
            Controls.Add(btnSubmit);
        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGuess.Text)) 
            {
                MessageBox.Show("enter a guess in the textbox");
            }
            else
            {
                // Grab the first letter in case they typed more than one
                var letter = txtGuess.Text[0];
                if (guesses.Contains(letter)) 
                {
                    MessageBox.Show("you already guessed that letter!");
                }
                else
                {
                    guesses.Add(letter);
                    lblWord.Text = string.Concat(
                        WordToGuess.Select(chr => guesses.Contains(chr) ? chr : '_'));
                }
            }
            txtGuess.Focus();
            txtGuess.Text = "";
        }
    }
