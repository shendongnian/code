        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.S | Keys.Alt))
            {
                MessageBox.Show("You pressed Alt+S");
            }
            else if (keyData == (Keys.Menu | Keys.Alt))
            {
                return false;
            }
            return true;
        }
