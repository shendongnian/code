    private void SetMessage(MyMessage message)
    {
      var text = message.Date.ToShortTimeString() + " " + message.Label + ": " +             message.TheMessage;
    
      switch (message.Type)
      {
         case GlobalVariables.MessageType.normal:
             rtxtMessage.SelectionColor = Color.Black;
             break;
         case GlobalVariables.MessageType.calculation:
             rtxtMessage.SelectionColor = Color.Green;
             break;
         case GlobalVariables.MessageType.error:
             rtxtMessage.SelectionColor = Color.Red;
             break;
         case GlobalVariables.MessageType.warning:
             rtxtMessage.SelectionColor = Color.Orange;
             break;
         default:
             break;
      }
      rtxtMessage.SelectedText = text + Environment.NewLine;
      rtxtMessage.ScrollToCaret();
    
      pnlMessage.Visible = true;
    }
