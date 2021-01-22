    public class PhoneNumberToString : ITwoWayConverter<long, string>
    {
        public string ConvertTo(long value)
        {
            return string.Format("{0:(###) ###-####}", Convert.ToInt64(value));
        }
        public int ConvertFrom(string value)
        {
            return System.Convert.ToInt64(Regex.Replace(value, @"\D", string.Empty));
        }
    }
