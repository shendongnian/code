    public class frmPassword
    {
        Public bool IsValidated { get; set;}
    
        public void btn_PasswordOK_Click(object sender, EventArgs e)
        {
    
            String s_pw = "ABC123";
            if(txt_Password.Text == s_pw)
            {
               IsValidated = true;
               this.Close();
            }
            else
            {
               MessageBox.Show("Wrong password! Try again or use Basic Mode");
            }
        }
    }
