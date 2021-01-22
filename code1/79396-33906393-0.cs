        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                // Setting e.IsInputKey to true will allow the KeyDown event to trigger.
                // See "Remarks" at https://msdn.microsoft.com/en-us/library/system.windows.forms.control.previewkeydown(v=vs.110).aspx
                e.IsInputKey = true;
            }
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            string send = "";
            if (e.KeyCode == Keys.PageUp)
            {
                send = "PGUP";
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                send = "PGDN";
            }
            else if (e.KeyCode == Keys.Up)
            {
                send = "UP";
            }
            else if (e.KeyCode == Keys.Down)
            {
                send = "DOWN";
            }
            if (send != "")
            {
                // We must focus the control we want to send keys to and use braces for special keys.
                // For a list of all special keys, see https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx.
                listBox.Focus();
                SendKeys.SendWait("{" + send + "}");
                textBox.Focus();
                // We must mark the key down event as being handled if we don't want the sent navigation keys to apply to this control also.
                e.Handled = true;
            }
        }
