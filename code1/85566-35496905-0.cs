    string pattern = null;
    pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
    if (Regex.IsMatch("txtemail.Text", pattern))
    {
    MessageBox.Show ("Valid Email address ");
    }
    else
    {
    MessageBox.Show("Invalid Email Email");
    }
