          Control.Changed += OnChanged;
    ...
    void OnChanged(object sender, EventArgs e)
    {
      _placeholderLabel.Hidden = Control.HasText;
    }
    
