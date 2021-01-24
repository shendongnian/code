    private void btnAddSave_Click(object sender, EventArgs e)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(txtAddEmployerName.Text, "^[a-zA-Z ]*$"))
        {
            MessageBox.Show("You may only enter letters", "Error");
            return;
        }
    }
