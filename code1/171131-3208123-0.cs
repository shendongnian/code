    public string MyHiddenValue
    {
        get { return hiddenField.Value; }
        set 
        {
            hiddenField.Value = value;
            if(MyHiddenValueChanged != null)
                MyHiddenValueChanged(this, new EventArgs());
        }
    }
    public event EventHandler MyHiddenValueChanged;
