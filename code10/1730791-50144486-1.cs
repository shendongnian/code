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
            int firstNumber;
            int secondNumber;
            if (!int.TryParse(TxtFirstNumber.Text, out firstNumber))
            {
                MessageBox.Show("first number is not a number");
                return;
            }
            else if (!int.TryParse(TxtSecondNumber.Text, out secondNumber))
            {
                MessageBox.Show("second number is not a number");
                return;
            }
            TxtResult.Text = Calculator.Add(firstNumber, secondNumber).ToString();
        }
    }
