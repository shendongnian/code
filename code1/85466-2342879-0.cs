    protected override bool ProcessMnemonic(char inputChar)
    {
        if (Control.ModifierKeys == Keys.Alt)
            return base.ProcessMnemonic(inputChar);
        return false;
    }
