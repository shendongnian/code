        private bool bLeftShiftKey = false;
        private bool bRightShiftKey = false;
        private bool IsValidDescriptionKey(Key key)
        {
            //KEYS ALLOWED IRREGARDLESS OF SHIFT KEY
            //various editing keys
            if (
            key == Key.Back ||
            key == Key.Tab ||
            key == Key.Up ||
            key == Key.Down ||
            key == Key.Left ||
            key == Key.Right ||
            key == Key.Delete ||
            key == Key.Space ||
            key == Key.Home ||
            key == Key.End
            ) {
                return true;
            }
            //letters
            if (key >= Key.A && key <= Key.Z)
            {
                return true;
            }
            //numbers from keypad
            if (key >= Key.NumPad0 && key <= Key.NumPad9)
            {
                return true;
            }
            //hyphen
            if (key == Key.OemMinus)
            {
                return true;
            }
            //KEYS ALLOWED CONDITITIONALLY DEPENDING ON SHIFT KEY
            if (!bLeftShiftKey && !bRightShiftKey)
            {
                //numbers from keyboard
                if (key >= Key.D0 && key <= Key.D9)
                {
                    return true;
                }
            }
            return false;
        }
        private void cboDescription_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
            {
                bLeftShiftKey = true;
            }
            if (e.Key == Key.RightShift)
            {
                bRightShiftKey = true;
            }
            if (!IsValidDescriptionKey(e.Key))
            {
                e.Handled = true;
            }
        }
        private void cboDescription_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
            {
                bLeftShiftKey = false;
            }
            if (e.Key == Key.RightShift)
            {
                bRightShiftKey = false;
            }
        }
