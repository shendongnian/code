    public bool PreFilterMessage(ref Message m)
    {
        Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
        bool retVal = false;
        if (m.Msg == WM_KEYDOWN)
        {
            // Handle the keypress
            retVal = true;
        }
        return retVal;
    }
