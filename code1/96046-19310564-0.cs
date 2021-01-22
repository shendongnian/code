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
