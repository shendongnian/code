    private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
    {
         if (e.Command == ApplicationCommands.Copy ||
             e.Command == ApplicationCommands.Cut  || 
             e.Command == ApplicationCommands.Paste)
         {
              e.Handled = true;
         }
    }
