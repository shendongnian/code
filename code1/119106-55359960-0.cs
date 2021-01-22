    private void OnCommandExecuting(object sender, Telerik.Windows.Documents.RichTextBoxCommands.CommandExecutingEventArgs e)
    {
        if (e.Command is PasteCommand)
        {
            //override paste when clipboard comes from out of RichTextBox (plain text)
            var documentFromClipboard = ClipboardEx.GetDocumentFromClipboard("RadDocumentGUID");
            if (documentFromClipboard == null)
            {
                (sender as RichTextBox).Insert(Clipboard.GetText());
                e.Cancel = true;
            }
        }
    }
