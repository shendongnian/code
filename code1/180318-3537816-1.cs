    public override string Text
    {
        get
        {
            return base.Text;
        }
        set
        {
            base.Text = value;
            this.selectionSet = false;
        }
    }
 
