    public class CustomStringBuilder 
    {
        private StringBuilder _builder;
        private string _prefix;
    
        public CustomStringBuilder (StringBuilder builder, string prefix)
        {
                _builder = builder;
                _prefix = prefix;
        }
    
        public MyStringBuilder CustomAppendLine(string text)
        {
            _builder .Append(_prefix);
            _builder .AppendLine(text);
            return this;
        }
        public override string ToString()
        {
            return _builder.ToString(); 
        }
    }
