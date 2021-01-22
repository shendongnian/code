    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var key = new KeyEventArgs(keyData);
    
            ShortcutKey(this, key);
    
            return base.ProcessCmdKey(ref msg, keyData);
        }
    
    
        protected virtual void ShortcutKey(object sender, KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.F2:
    dataGridView1.EndEdit();
                    MessageBox.Show(dataGridView1.SelectedCells[0].Value.ToString());
                    break;
            }
        }
