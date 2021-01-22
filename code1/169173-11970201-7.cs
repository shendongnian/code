    void ValidateKeyPress(object sender, KeyEventArgs e)
    {
        char keyPressed = WPFUtils.Interop.Keyboard.GetCharFromKey(e.Key);
        if (!Char.IsNumber(keyPressed) && !Char.IsControl(keyPressed))
        {
            //As above
            e.Handled = true;
            return;
        }
    }
