    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Left)
        {
            MoveLeft(); DrawGame(); DoWhatever();
            return true; //for the active control to see the keypress, return false
        }
        else if (keyData == Keys.Right)
        {
            MoveRight(); DrawGame(); DoWhatever();
            return true; //for the active control to see the keypress, return false
        }
        else if (keyData == Keys.Up)
        {
            MoveUp(); DrawGame(); DoWhatever();
            return true; //for the active control to see the keypress, return false
        }
        else if (keyData == Keys.Down)
        {
            MoveDown(); DrawGame(); DoWhatever();
            return true; //for the active control to see the keypress, return false
        }
        else
            return base.ProcessCmdKey(ref msg, keyData);
    }
          
