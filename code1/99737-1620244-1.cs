    private bool _useProxy;
    private bool UseProxy
    {
        get
        {
            return _useProxy;
        }
        set
        {
            bool valueChanged = _useProxy != value;
            _useProxy = value;
            if (valueChanged)
            {
                SetControlStates();
            }
        }
    }
    
    private void SetControlStates()
    {
        groupBox2.Enabled = this.UseProxy;
        checkBox1.Checked = this.UseProxy;
    }
    
    private void checkBox1_CheckedChanged(object sender, EventArgs 
        this.UseProxy = checkBox1.Checked;
    }
