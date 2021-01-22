    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // check the key to see if it should be handled in the OnKeyPress method
        // the reasons for doing this check here is:
        // 1. The KeyDown event sees certain keypresses differently, e.g NumKeypad 1 is seen as a lowercase A
        // 2. The KeyPress event cannot see Modifer keys so cannot see Ctrl-C,Ctrl-V etc.
        // The functionality of the ProcessCmdKey has not changed, it is simply doing a precheck before the 
        // KeyPress event runs
        switch (keyData)
        {
            case Keys.V | Keys.Control :
            case Keys.C | Keys.Control :
            case Keys.X | Keys.Control :
            case Keys.Back :
            case Keys.Delete :
                this._handleKey = true;
                break;
            default:
                this._handleKey = false;
                break;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
 
 
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (String.IsNullOrEmpty(this._ValidCharExpression))
        {
            this._handleKey = true;
        }
        else if (!this._handleKey)
        {
            // this is the final check to see if the key should be handled
            // checks the key code against a validation expression and handles the key if it matches
            // the expression should be in the form of a Regular Expression character class
            // e.g. [0-9\.\-] would allow decimal numbers and negative, this does not enforce order, just a set of valid characters
            // [A-Za-z0-9\-_\@\.] would be all the valid characters for an email
            this._handleKey = Regex.Match(e.KeyChar.ToString(), this._ValidCharExpression).Success;
        }
        if (this._handleKey)
        {
            base.OnKeyPress(e);
            this._handleKey = false;
        }
        else
        {
            e.Handled = true;
        }
        
    }
