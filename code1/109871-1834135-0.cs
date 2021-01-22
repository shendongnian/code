    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if(GridControlFocused)
        {
            switch(keyData)
            {
               case Keys.Tab:
               // put code here to jump to next cell.
               return true;
            }
        }
        
        return base.ProcessCmdKey(ref msg, keyData);
    }
