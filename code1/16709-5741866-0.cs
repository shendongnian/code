        static bool AltGr;
        void Numclient_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.Key == 6)
            {
                AltGr = false;
            }
        }
        void Numclient_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.Key == 6)
            {
                AltGr = true;
            }
            if (Keyboard.Modifiers == ModifierKeys.Shift || AltGr == true)
            {
                e.Handled = true;
            }
            if (e.Handled == false && (e.Key < Key.D0 || e.Key > Key.D9))
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if (e.Key != Key.Back)
                    {
                        e.Handled = true;
                    }
                }
            }       
        }
