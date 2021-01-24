     dialog.Closing += DialogClosingEvent;
    
     private void DialogClosingEvent(ContentDialog sender, ContentDialogClosingEventArgs args)
     {
          // This mean user does click on Primary or Secondary button
          if(args.Result == ContentDialogResult.None)
          {
               args.Cancel = true;
          }
     }
