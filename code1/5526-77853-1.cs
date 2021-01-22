    private bool CheckValidNumber()
    {
       if (Regex.Match(this.Text, this.RegexPattern).Value != this.Text)
       {
           this._errorProvider.SetError(this, this.ValidationError);
           return false;
       }
       this._errorProvider.Clear();
       return true;
    }
        
    protected override void OnValidating(CancelEventArgs e)
    {
       bool flag = this.CheckValidNumber();
       if (!flag)
       {
          e.Cancel = true;
          this.Text = "0";
       }
       base.OnValidating(e);
       if (!flag)
       {
          this.ValidationFail(this, EventArgs.Empty);
       }
    }
