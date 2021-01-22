    [Editor("System.Windows.Forms.Design.StringArrayEditor, 
             System.Design, Version=2.0.0.0, 
             Culture=neutral, 
             PublicKeyToken=b03f5f7f11d50a3a", 
             typeof(UITypeEditor))]
    public string[] Lines
    {
        get { return _lines; }
        set { _lines = value; }
    }
