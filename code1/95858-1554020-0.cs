    [Description("abc")]
    [I18NDescriptionAttribute("abc")]
    public string Name { get; set; }
    
    class I18NDescriptionAttribute : DescriptionAttribute {
        public I18NDescriptionAttribute(string resxKey) : base(resxKey) { } 
    }
