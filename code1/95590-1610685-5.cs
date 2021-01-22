        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D){
                e.Handled = true;
                SendKeys.Send("F");
            }
        }
