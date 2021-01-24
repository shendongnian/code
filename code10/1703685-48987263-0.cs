    private string customProperty;
    [WebBrowsable(true),
    Category("Custom Properties"),
    WebDisplayName("CustomProperty"),
    WebDescription("CustomProperty Description"),
    Personalizable(PersonalizationScope.Shared)]
    public string CustomProperty
    {
    	get { return customProperty; }
    	set { customProperty = value; }
    }
