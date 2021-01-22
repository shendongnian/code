    class Name : Attribute
    {
        public string Text;
        public Name(string text)
        {
            this.Text = text;
        }
    }
    class Description : Attribute
    {
        public string Text;
        public Description(string text)
        {
            this.Text = text;
        }
    }
    public enum DaysOfWeek
    {
        [Name("FirstDayOfWeek")]
        [Description("This is the first day of 7 days")]
        Sunday = 1,
        [Name("SecondDayOfWeek")]
        [Description("This is the second day of 7 days")]
        Monday= 2,
        [Name("FirstDayOfWeek")]
        [Description("This is the Third day of 7 days")]
        Tuesday= 3,
    }
