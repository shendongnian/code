    private void cbShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowHide.Checked)
            {
                txtPin.UseSystemPasswordChar = 
                  PasswordPropertyTextAttribute.No.Password;
            }
            else
            {
                //Hides Textbox password
                txtPin.UseSystemPasswordChar = 
                 PasswordPropertyTextAttribute.Yes.Password;
            }
        }
 
