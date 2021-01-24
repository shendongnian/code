    private void Textbox_KeyUp(object sender, KeyEventArgs e)
    {
        if (textbox.Text != string.Empty && e.Key != Key.Back)
         {
             this.ShowMessageAsync("This is the title", "Some message");
         }
    }
