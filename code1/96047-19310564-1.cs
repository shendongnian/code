    private void emailTxt_Validating(object sender, CancelEventArgs e)
        
    {
    System.Text.RegularExpressions.Regex rEmail = new    System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (emailTxt.Text.Length > 0 && emailTxt.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(emailTxt.Text.Trim()))
                {
                    MessageBox.Show("check email id");
                    emailTxt.SelectAll();
                    e.Cancel = true;
                }
            }
        }
