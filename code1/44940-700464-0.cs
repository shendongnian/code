    private void txtShortcut_KeyDown(object sender, KeyEventArgs e)
        {
                    // Example key press: Ctrl + A
            if ((e.Shift || e.Control || e.Alt) && 
    			(((e.KeyCode >= Keys.a) && (e.KeyCode <= Keys.z)) ||
    			((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z)) ||
    			((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9)) ||
    			((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9))))
            {
                string s = (e.Shift ? Keys.ShiftKey.ToString() + " + " : "") + // Shift
                                    (e.Control ? Keys.ControlKey.ToString() + " + " : "") +  // Control
                                            (e.Alt ? Keys.Menu.ToString() + " + " : "") +  // Alt (menu)
                                                    e.KeyCode; // Key.
    
                lbLogger.Items.Add(s);
                            // Logger Results:
                            // 1) ControlKey + ControlKey
                            // 2) ControlKey + A
                // * I'm trying to get it to only post the second line and only log the line
                // when a modifier key + a-z 0-9 key is pressed with it.
            }
        }
