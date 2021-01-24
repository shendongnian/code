    public partial class Form1 : Form
    {
        int Total; //or "public int Total { get; set; }"
        public Form1()
        {
            InitializeComponent();
            Random rand = new Random();
            int NumberOne = rand.Next(500) + 100;
            int NumberTwo = rand.Next(500) + 100;
            lblEquation.Text = NumberOne.ToString() + " + " + NumberTwo.ToString() + "= ?";
            Total = NumberOne + NumberTwo;
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            int UsersInput;
            UsersInput = Convert.ToInt32(txtInput.Text);
            if ( Total == UsersInput)
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }
    }
