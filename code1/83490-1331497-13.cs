    using System.Reflection;
    class DescriptionAttribute : Attribute
    {
        public string Text { get; private set; }
        public DescriptionAttribute(string text)
        {
            this.Text = text;
        }
    }
    enum MyEnum
    {
        [Description("This is black")]
        Black,
        [Description("This is white")]
        White
    }
