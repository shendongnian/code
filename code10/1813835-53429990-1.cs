    public class CustomStringBuilder : StringBuilder
    {
        public CustomAppendLine (string text)
        {
            base.AppendLine("- " + text)
        }
    }
