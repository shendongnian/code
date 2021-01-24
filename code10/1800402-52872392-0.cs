    public string[] LoanTypesSelection => new string[]
    {
        "Student Loan",
        "Mortgage"
    };
    void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if(!(sender is Picker loantype))
        {
            return;
        }
        if ((loantype.SelectedIndex > LoanTypesSelection.Length) ||
            (loantype.SelectedIndex < 0))
        {
            // Display an error message?
            return;
        }
        MyLabel.Text = LoanTypesSelection[loantype.SelectedIndex]; // Or whatever
    }
