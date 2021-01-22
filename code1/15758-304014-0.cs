    protected override void OnKeyDown(KeyEventArgs e)
     {
        Keys keyCode = (Keys)e.KeyValue;
        base.OnKeyDown(e);
        if ((e.Modifiers == Keys.Control) ||
           (e.Modifiers == Keys.Control) ||
           (keyCode == Keys.Back) ||
           (keyCode == Keys.Delete))
        {
          this._handleKey = true;
        }
        else
        {
          // check if the key is valid and set the flag
          this._handleKey = Regex.Match(key.ToString(), this._ValidCharExpression).Success;
        }
      }
    
      
      
    
    protected override void OnKeyPress(KeyPressEventArgs e)
      {
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
