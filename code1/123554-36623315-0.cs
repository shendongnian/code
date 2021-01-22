        private void YourForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (e.Modifiers == Keys.Shift)
                    this.ProcessTabKey(false);
                else
                    this.ProcessTabKey(true);
            }
        }
