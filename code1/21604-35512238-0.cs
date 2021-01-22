    private void textBoxFileName_KeyPress(object sender, KeyPressEventArgs e)
    {
       e.Handled = CheckFileNameSafeCharacters(e);
    }
    /// <summary>
    /// This is a good function for making sure that a user who is naming a file uses proper characters
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    internal static bool CheckFileNameSafeCharacters(System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar.Equals(24) || 
            e.KeyChar.Equals(3) || 
            e.KeyChar.Equals(22) || 
            e.KeyChar.Equals(26) || 
            e.KeyChar.Equals(25))//Control-X, C, V, Z and Y
                return false;
        if (e.KeyChar.Equals('\b'))//backspace
            return false;
        char[] charArray = Path.GetInvalidFileNameChars();
        if (charArray.Contains(e.KeyChar))
           return true;//Stop the character from being entered into the control since it is non-numerical
        else
            return false;            
    }
