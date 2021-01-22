    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if ((!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) && (!this._numberSymbols.Contains(e.KeyChar.ToString()) && !this._numericSeparator.Contains(e.KeyChar.ToString())))
        {
            e.Handled = true;
        }
        if (this._numberSymbols.Contains(e.KeyChar.ToString()) && !this._forcePositives)
        {
            e.Handled = true;
        }
        if (this._numericSeparator.Contains(e.KeyChar.ToString()) && this._useIntegers)
        {
            e.Handled = true;
        }
        base.OnKeyPress(e);
    }
