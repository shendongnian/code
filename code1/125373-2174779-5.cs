    public class PhoneNumberToString : ITwoWayConverter<long, string>
    {
        public string ConvertForward(long value)
        {
            return string.Format("{0:(###) ###-####}", Convert.ToInt64(value));
        }
        public int ConvertBackward(string value)
        {
            return Convert.ToInt64(Regex.Replace(value, @"\D", string.Empty));
        }
    }
