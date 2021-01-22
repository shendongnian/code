    private void scrollViewer_KeyDown(object sender, KeyEventArgs e)
    {
        if (!e.IsRepeat)
        {
            var keyPressed = e.Key.ToString();
            if(keyPressed.Length == 1)
                CharKeyPressed(keyPressed[0]);
            else if(keyPressed.Length > 1)
                HandleSpecialKey(keyPressed)
        }
    }
