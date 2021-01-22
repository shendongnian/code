       public Keys UnmodifiedKey(Keys key)
        {
            return key & Keys.KeyCode;
        }
        public bool KeyPressed(Keys key, Keys test)
        {
            return UnmodifiedKey(key) == test;
        }
        public bool ModifierKeyPressed(Keys key, Keys test)
        {
            return (key & test) == test;
        }
        public bool ControlPressed(Keys key)
        {
            return ModifierKeyPressed(key, Keys.Control);
        }
        public bool AltPressed(Keys key)
        {
            return ModifierKeyPressed(key, Keys.Alt);
        }
        public bool ShiftPressed(Keys key)
        {
            return ModifierKeyPressed(key, Keys.Shift);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (KeyPressed(keyData, Keys.Left) && AltPressed(keyData))
            {
                int n = code.Text.IndexOfPrev('<', code.SelectionStart);
                if (n < 0) return false;
                if (ShiftPressed(keyData))
                {
                    code.ExpandSelectionLeftTo(n);
                }
                else
                {
                    code.SelectionStart = n;
                    code.SelectionLength = 0;
                }
                return true;
            }
            else if (KeyPressed(keyData, Keys.Right) && AltPressed(keyData))
            {
                if (ShiftPressed(keyData))
                {
                    int n = code.Text.IndexOf('>', code.SelectionEnd() + 1);
                    if (n < 0) return false;
                    code.ExpandSelectionRightTo(n + 1);
                }
                else
                {
                    int n = code.Text.IndexOf('<', code.SelectionStart + 1);
                    if (n < 0) return false;
                    code.SelectionStart = n;
                    code.SelectionLength = 0;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
