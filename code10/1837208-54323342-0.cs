    private void Phonenumber_KeyPress(object sender, KeyPressEventArgs e)
    {
         e.Handled= IsWrongkeypress(e.KeyChar)
    }
    
    public Boolean  IsWrongkeypress(char ch)
            {
                Boolean ishandled =false ;
    
                if (!char.IsDigit(ch) && (ch != 8))
                {
                    ishandled = true;
                }
    
                return ishandled;
            }
