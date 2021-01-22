    if (this.ActiveControl is TextBox)
    {
          Clipboard.SetDataObject(((TextBox)this.ActiveControl).SelectedText, true);
    }
    if (this.ActiveControl is RichTextBox)
    {
          Clipboard.SetDataObject(((RichTextBox)this.ActiveControl).SelectedText, true);
    }
    if (this.ActiveControl is ComboBox)
    {
           Clipboard.SetDataObject(((ComboBox)this.ActiveControl).SelectedText, true);
    }
