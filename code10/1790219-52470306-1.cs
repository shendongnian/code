    //is a valid operator
    public bool IsOperator(TextBox textBox, string name)
    {
        string operator = textBox.Text;
        if (new[] {"+", "-", "*", "/"}.Contains(operator))
        {
             return true;
        }
        MessageBox.Show("Please enter a valid operator in the operator text box.", "Entry Error");
        return false; 
    }
