    public void SET_VAL(string mytype, string myvalue)
    {
        this.GetType().GetField(mytype).SetValue(this, myvalue);
        MessageBox.Show(a);
    }
