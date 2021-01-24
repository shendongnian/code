    private void nFactorial_Click(object sender, EventArgs e)
    {
        long facOut, factorial;
        long num = 20;
        factorial = 1;
        for (facOut = 1; facOut <= num; facOut++)
        {
            factorial *= facOut;
            tb.Text += factorial.ToString() + Environment.NewLine;
        }
    }
