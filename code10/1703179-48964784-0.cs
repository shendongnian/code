    private void textBox__TextChanged(object sender, EventArgs e)
    {
        if (txtUsername.Text != "" || txtPassword.Text != "" || txtID.Text != "" || txtFirstName.Text != "" || txtMiddleName.Text != "" || txtLastName.Text != "" || txtDep.Text != "")
        {
            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }
    }
