    void ValidateKeyPress(object sender, KeyEventArgs e)
    {
        char keyPressed = WPFUtils.Interop.Keyboard.GetCharFromKey(e.Key);
        if (!Char.IsNumber(keyPressed) && !Char.IsControl(keyPressed))
        {
            //The char is not a number or a control key
            //Handle the event so the key press is ignored
            e.Handled = true;
        }
    }
