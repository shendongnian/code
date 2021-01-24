    public static void CheckForbarcode(TextBox origin)
    {
    string data=origin.Text;
    // asssuming your barcode is 12 digit long
    
        if(data.Length==12)
        {
         //Regex Pattern goes here
         origin.Text="";
         Barcode.text=data;
        }
    
    }
