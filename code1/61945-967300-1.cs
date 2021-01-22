    private void TextBox_GotFocus(object sender, EventArgs e)
    {
        SetKeyboardVisible(true);
    }
    
    private void TextBox_LostFocus(object sender, EventArgs e)
    {
        SetKeyboardVisible(false);
    }
    
    protected void SetKeyboardVisible(bool isVisible)
    {
        inputPanel.Enabled = isVisible;
    }
