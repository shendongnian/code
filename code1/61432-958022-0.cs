    public class StringWrapper
    {
        public string Value { get; set; }
        public StringWrapper()
        {
            this.Value = string.Empty;
        }
        public StringWrapper(string value)
        {
            this.Value = value;
        }
        public static StringWrapper operator *(StringWrapper wrapper,
                                               int timesToRepeat)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < timesToRepeat; i++)
            {
                builder.Append(wrapper.Value);
            }
            return new StringWrapper(builder.ToString());
        }
    }
