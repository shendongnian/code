     <xctk:RichTextBox Name="Description" CommandManager.PreviewExecuted="CommandExecuted_PreviewExecuted"> 
     private void CommandExecuted_PreviewExecuted(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.RichTextBox richTextBox =  (Xceed.Wpf.Toolkit.RichTextBox)sender;
            string rtbtext = StringFromRichTextBox(richTextBox);
            if ((e as ExecutedRoutedEventArgs).Command == ApplicationCommands.Paste)
            {
                // verify that the textbox handled the paste command
                if (Clipboard.GetText() > 2500)//Get copied text from clipboard
                {
                    e.Handled = true;// prevent paste if length is more than 2500.
                    return;
                }
            }
        } 
