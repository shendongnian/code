     public partial class Form1 : Form
    {
        int Count = 0;
        decimal Total = 0m;
        decimal[] scores = new decimal[20];
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal Score = Convert.ToDecimal(txtScore.Text);
            //Add the score to the array
            scores[Count] = Score;
            Total += Score;
            Count++;
            decimal Average = Total / Count;
            txtTotal.Text = Total.ToString();
            txtCount.Text = Count.ToString();
            txtAverage.Text = Average.ToString();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            int Count = 0;
            decimal Total = 0m;
            decimal Average = 0m;
            decimal Score = 0m;
            txtScore.Text = Score.ToString();
            txtAverage.Text = Average.ToString();
            txtTotal.Text = Total.ToString();
            txtCount.Text = Count.ToString();
            
            txtScore.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The scores entered are " + Environment.NewLine +
                scores[0] + Environment.NewLine +
                scores[1] + Environment.NewLine +
                scores[2] + Environment.NewLine +
                scores[3] + Environment.NewLine +
                scores[4] + Environment.NewLine +
                scores[5] + Environment.NewLine +
                scores[6] + Environment.NewLine +
                scores[7] + Environment.NewLine +
                scores[8] + Environment.NewLine +
                scores[9] + Environment.NewLine +
                scores[10] + Environment.NewLine +
                scores[11] + Environment.NewLine +
                scores[12] + Environment.NewLine +
                scores[13] + Environment.NewLine +
                scores[14] + Environment.NewLine +
                scores[15] + Environment.NewLine +
                scores[16] + Environment.NewLine +
                scores[17] + Environment.NewLine +
                scores[18] + Environment.NewLine +
                scores[19] + Environment.NewLine, "Scores List");
            
        }
    }
