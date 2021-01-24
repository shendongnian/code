    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendLineIf(this StringBuilder builder, bool condition, string line)
        {
            // validate arguments
            if (condition) 
                builder.AppendLine(line);
            return builder;            
        }
        public static StringBuilder AppendIf(this StringBuilder builder, bool condition, string line)
        {
            // validate arguments
            if (condition) 
                builder.Append(line);
            return builder;            
        }
    }
    StringBuilder builder = new StringBuilder();
    builder.AppendLineIf(1 == 1, "- hint 1");
    builder.AppendLineIf(2 == 2, "- hint 2");
    builder.AppendLineIf(3 == 3, "- hint 3");
    string result = builder.ToString();
    // do something with result
