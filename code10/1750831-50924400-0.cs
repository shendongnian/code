    [MarkupOptions(AllowHardCodedValue = false)]
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    public static readonly DotvvmProperty TextProperty
        = DotvvmProperty.Register<string, TextBoxWithLabel>(c => c.Text, "");
