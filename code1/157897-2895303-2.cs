    DateTime lastKeyPress = DateTime.Now;
    
    void txtBarcode_KeyPress(object sender, KeyPressEventArgs args)
    {
    
       if(((TimeSpan) (DateTime.Now - lastKeyPress)).TotalMilliseconds > 10)
       {
         txtBarcode.Text = "";      
       }
       lastKeyPress = DateTime.Now;
    }
