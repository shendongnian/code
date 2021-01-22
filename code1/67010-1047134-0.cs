    public class AlphaNumericString
    {
        public AlphaNumericString(string s)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (r.IsMatch(s))
            {
                value = s;                
            }
            else
            {
                throw new ArgumentException("Only alphanumeric characters may be used");
            }
        }
        private string value;
        static public implicit operator string(AlphaNumericString s)
        {
            return s.value;
        }
    }
