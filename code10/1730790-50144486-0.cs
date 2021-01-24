    internal static class Calculator
    {
        public static int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
    
    public partial class Form1 : Form
    {
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            TxtResult.Text = Calculator.Add(Convert.ToInt32(TxtFirstNumber.Text), Convert.ToInt32(TxtSecondNumber.Text)).ToString();
        }
    }
