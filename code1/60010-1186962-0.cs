    public static DependencyProperty FromProperty = DependencyProperty.Register("From", typeof(string), typeof(SendMailActivity));
    [DescriptionAttribute("The email of the sender")]
    [CategoryAttribute("Parameters")]
    [BrowsableAttribute(true)]
    [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
    public string From
    {
        get
        {
            return ((string)(base.GetValue(SendMailActivity.FromProperty)));
        }
        set
        {
            base.SetValue(SendMailActivity.FromProperty, value);
        }
    }
