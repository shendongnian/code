    DateTime lastKeyPress = DateTime.Now;
    
    void TextBox_KeyPress(object sender, KeyPressEventArgs args)
    {
    
       if(((TimeSpan) (DateTime.Now - lastKeyPress)).TotalMilliseconds > 10)
       {
         TextBox.Text = "";      
       }
       lastKeyPress = DateTime.Now;
    }
