    if (String.IsNullOrEmpty(txtBenutzerName.Text))
    {
        txtBenutzerName.BackColor = Color.Red;
    }
    else
    {
        txtBenutzerName.BackColor = SystemColors.Window;
    }
    if (String.IsNullOrEmpty(txtPasswort.Text))
    {
        txtPasswort.BackColor = Color.Red;
    }
    else
    {
        txtPasswort.BackColor = SystemColors.Window;
    }
