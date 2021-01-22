    private string FirstNumber { get; set; }
    private string SecondNumber { get; set; }
    private bool IsSecondNumberBeingEntered { get; set; }
    private Operation SelectedOperation { get; set;}
    private enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    private void button0_Click(object sender, EventArgs e)
    {
        this.AddNumber(0);
        textBox1.Text = textBox1.Text + "0";
    }
    // Etc.
    // In PreviewKeyDown:
    if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
    {
        this.AddNumber(0);
    }
    private void AddNumber(int number)
    {
        if (IsSecondNumberBeingEntered)
        {
            SecondNumber += number.ToString();
        }
        else
        {
            FirstNumber += number.ToString();
        }
    }
    private decimal Calculate()
    {
        switch (SelectedOperation)
        {
            case Operation.Add:
                return Convert.ToDecimal(FirstNumber) + Convert.ToDecimal(SecondNumber);
            case Operation.Subtract:
                return Convert.ToDecimal(FirstNumber) - Convert.ToDecimal(SecondNumber);
            // etc.
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
