    protected void btn_Clicked(object sender, EventAgrs e)
    {
       //get your command argument from the button here
       if (sender is Button)
       {
         try
         {
            String yourAssignedValue = ((Button)sender).CommandArgument;
         }
         catch
         {
           //Check for exception
         }
       }
    }
