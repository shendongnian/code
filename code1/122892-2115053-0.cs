        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                // do something
            }
            if (keyData == Keys.Escape)
            {
                // do something else
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
