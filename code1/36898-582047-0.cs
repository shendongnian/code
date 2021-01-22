    void AccountChangedHandler(object sender, EventArgs e)
    {
       string n = ((TextBox)sender).Name;
       string t = ((TextBox)sender).Text;
       // or instead of cast
       TextBox tb = sender as TextBox; // if sender is another type, tb is null
       if(tb != null)
       {
         string n = tb.Name;
         string t = tb.Text;
       }
    }
