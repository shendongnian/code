    class class1
    {
        public static int AddTwoNumbers(int FirstNumber, int SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
    }
    
    public partial class form1 : Form
    {
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
           int v1 = Convert.ToInt32(TxtFirstNumber.Text);
           int v2 = Convert.ToInt32(TxtSecondNumber.Text);
           int result = Class1.AddTwoNumbers(v1, v2);
           TxtResult.Text = result.ToString();
        }
    }
