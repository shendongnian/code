    public static List<Keys> keysDown = new List<Keys>();
    private static void HookManager_KeyDown(object sender, KeyEventArgs e)
            {
                //Used for overriding the Windows default hotkeys
                if(keysDown.Contains(e.KeyCode) == false)
                {
                    keysDown.Add(e.KeyCode);
                }
    
                if (e.KeyCode == Keys.Right && WIN())
                {
                    e.Handled = true;
                    //Do what you want when this key combination is pressed
                }
                else if (e.KeyCode == Keys.Left && WIN())
                {
                    e.Handled = true;
                    //Do what you want when this key combination is pressed
                }
    
            }
    
            private static void HookManager_KeyUp(object sender, KeyEventArgs e)
            {
                //Used for overriding the Windows default hotkeys
                while(keysDown.Contains(e.KeyCode))
                {
                    keysDown.Remove(e.KeyCode);
                }
            }
    
            private static void HookManager_KeyPress(object sender, KeyPressEventArgs e)
            {
                //Used for overriding the Windows default hotkeys
    
            }
    
            public static bool CTRL()
            {
                //return keysDown.Contains(Keys.LShiftKey)
                if (keysDown.Contains(Keys.LControlKey) || 
                    keysDown.Contains(Keys.RControlKey) || 
                    keysDown.Contains(Keys.Control) || 
                    keysDown.Contains(Keys.ControlKey))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            public static bool SHIFT()
            {
                //return keysDown.Contains(Keys.LShiftKey)
                if (keysDown.Contains(Keys.LShiftKey) || 
                    keysDown.Contains(Keys.RShiftKey) ||
                    keysDown.Contains(Keys.Shift) ||
                    keysDown.Contains(Keys.ShiftKey))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            public static bool WIN()
            {
                //return keysDown.Contains(Keys.LShiftKey)
                if (keysDown.Contains(Keys.LWin) || 
                    keysDown.Contains(Keys.RWin))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            public static bool ALT()
            {
                //return keysDown.Contains(Keys.LShiftKey)
                if (keysDown.Contains(Keys.Alt))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
