    protected void btn_Clicked(object sender, EventAgrs e)
    {
       //get your command argument from the button here
       if (sender is Button)
       {
         try
         {
           int index = Convert.ToInt32(((Button)sender).CommandArgument);
         }
         catch
         {
           //Check for exception
         }
       }
    }
