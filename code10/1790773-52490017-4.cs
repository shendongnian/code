    private void btnSignIn_Click(object sender, EventArgs e)
    {
        GetInputs();
        var validationResult = IsValidata();
        if (validationResult.IsValid)
        {
            de.Text = string.Format("Hello! {0} {1} {2}{3} {4} {5})",
                Fname, Lname, "(U", Unum1, "-", Unum2);
            this.Hide();
            de.ShowDialog();
        }
        else
        { 
            // Show a message box, with an OK button only
            MessageBox.Show(validationResult.UserMessage, "Invalid Input", MessageBoxButtons.OK);
        }
    }
