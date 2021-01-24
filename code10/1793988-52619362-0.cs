     public partial class frmAdditionTutor : Form
        {
            public int CorrectAnswerCount = 0;
            public int IncorrectAnswerCount = 0;
            int NumberOne = 0;
            int NumberTwo = 0;
            public Form1()
            {
                InitializeComponent();
                CreateRandomQuestion();
            }
    
            private void btnSolve_Click(object sender, EventArgs e)
            {
                int TotalAmount = NumberOne + NumberTwo;
                int UserInputs = Convert.ToInt32(txtInput.Text);
    
                if (TotalAmount == UserInputs)
                {
                    lblRightorWrong.Text = "Correct!";
                    CorrectAnswerCount++;
                    txtAmountCorrect.Text = CorrectAnswerCount.ToString();
                }
                else
                {
                    lblRightorWrong.Text = "Incorrect!";
                    IncorrectAnswerCount++;
                    txtAmountWrong.Text = IncorrectAnswerCount.ToString();
                }
    
                CreateRandomQuestion();
            }
    
            public void CreateRandomQuestion()
            {
                Random rand = new Random();
                NumberOne = rand.Next(500) + 100;
                NumberTwo = rand.Next(500) + 100;
                lblEquation.Text = NumberOne.ToString() + " + " + NumberTwo.ToString() + "= ?";
                txtInput.Clear();
            }
        }
