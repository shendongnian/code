    private void SetMessages()
    {
       rtxtMessage.Text = "";
       lock(GlobalVariables.MessageList)
       {
          foreach (var message in GlobalVariables.MessageList)   
          { 
             //Rest of your code 
          }   
          pnlMessage.Visible = true;
       }
    }
