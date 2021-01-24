    private void nFactorial_Click(object sender, EventArgs e)
    {
        long facOut, factorial, number;
        long num = 20;
        factorial = num;
        for (facOut = num - 1; facOut >= 1; facOut--)
        {
           factorial *= facOut;         
           nFactorial.Text += factorial.ToString() + Environment.NewLine;  
        }
    }
