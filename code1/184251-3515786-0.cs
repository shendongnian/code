    public Template NewTemplate
    {
        get
        {
            return (Template)GetValue(NewTemplateProperty);
        }
        set
        {
            SetValue(NewTemplateProperty, value);
            // The magic line, explicitly setting TemplateData property on
            // the TemplateDetails UserControl:
            uct_templateDetails.TemplateData = value;
        }
    }
