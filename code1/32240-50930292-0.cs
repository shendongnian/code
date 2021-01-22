    public class Bar : IFoo
    {
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(Bar)}";
        }
        public override string ToString()
        {
            return ToString(null, System.Globalization.CultureInfo.CurrentCulture);
        }
    }
