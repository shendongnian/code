    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void termTextBox_TextChanged(object sender, EventArgs e)
        {
            int numberOfTerms;
            if (Int32.TryParse(termTextBox.Text, out numberOfTerms) && numberOfTerms > 0)
            {  
              this.approxLbl.Text = "Approximate the value of pi after " + numberOfTerms + " terms";
              this.calculateBtn.Enabled = true;
            }
            else
            {
                this.approxLbl.Text = "Number of terms must be a positive integer.";
            }
        }
        private void calculateBtn_Click(object sender, EventArgs e)
        {
            //the approximation of pi is given by 4/1 – 4/3 + 4/5 – 4/7 + 4/9 ... number of terms
            double numerator = 4;
            double denominator = 1;
            int numberOfTerms;
            Int32.TryParse(termTextBox.Text, out numberOfTerms);
            double approximation = 0;
            for (int i = 1; i <= numberOfTerms; i++)
            {
                //change the operation each cycle
                if(i % 2 != 0)
                {
                    approximation += numerator / denominator;
                }
                else
                {
                    approximation -= numerator / denominator;
                }
                denominator += 2;
            }
            this.resultLbl.Text = "The approximation is " + approximation;
        }
    }
