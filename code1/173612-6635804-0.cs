    protected override bool IsInputKey(Keys keyData)
    {
        if (
            (keyData & ~Keys.Modifiers) == Keys.Tab &&
            (keyData & (Keys.Control | Keys.Alt)) == 0
        )
            return false;
        return base.IsInputKey(keyData);
    }
