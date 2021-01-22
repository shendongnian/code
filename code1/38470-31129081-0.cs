      protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            TextBox tbTo = (TextBox)sender;
            DateTime wsToOUT;
            if (DateTime.TryParse(tbTo.Text, out wsToOUT))
            {
                //do something with valid date in tbTo
            }
            else
            {
                //show a nice error message
                tbTo.Focus();
            }
        }
