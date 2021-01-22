    void ValidateKeyPress(object sender, KeyEventArgs e)
    {
        char keyPressed = WPFUtils.Interop.Keyboard.GetCharFromKey(e.Key);
        if (Char.IsNumber(keyPressed) || Char.IsControl(keyPressed))
        {
            //The character is a number or a control key, so handle the event
            e.Handled = true;
        }
    }
