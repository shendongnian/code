    public class CustomStringBuilder : StringBuilder
    {
        public CustomAppendLine (string text)
        {
            this.AppendLine("- " + text)
        }
    }
