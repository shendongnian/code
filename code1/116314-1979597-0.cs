    public BaseControl
    {
        public void RenderControl(HTMLWriter writer) {}
    }
    public TextBox : BaseControl
    {
        public string Text { get;set; }
    }
    public static T TabIndex<T>(this T control, int index) where T : BaseControl {}
