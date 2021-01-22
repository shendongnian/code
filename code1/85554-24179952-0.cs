        public static bool IsValidEmailId(string InputEmail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }
    
        protected void Email_TextChanged(object sender, EventArgs e)
        {
            String UserEmail = Email.Text;
            if (IsValidEmailId(UserEmail))
            {
                Label4.Text = "This email is correct formate";
            }
            else
            {
                Label4.Text = "This email isn't correct formate";
            }
        }
