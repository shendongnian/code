    // Updates the textbox text.
    private void UpdateText(string text)
    {
      // Set the textbox text.
      m_TextBox.Text = text;
    }
    public delegate void UpdateTextCallback(string text);
    // Then from your thread you can call this...
    m_TextBox.Invoke(new UpdateTextCallback(this.UpdateText),
        new object[]{"Text generated on non-UI thread."});
