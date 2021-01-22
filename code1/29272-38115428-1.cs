    private void ultraTextEditor1_TextChanged(object sender, EventArgs e)
    {
        string append="";
        foreach (char c in ultraTextEditor1.Text)
        {
            if ((!Char.IsNumber(c)) && (c != Convert.ToChar(Keys.Back)))
            {
                       
            }
            else
            {
                append += c;
            }
        }
        
        ultraTextEditor1.Text = append;
    }   
 
