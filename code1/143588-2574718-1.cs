    // the simplest attribute class is enough for you:
    [AttributeUsage(AttributeTargets.Property)]
    public class LegacyNameAttribute : Attribute
    {
        public string Name { get; set; }
        public LegacyNameAttribute(string name)
        {
            this.Name = name;
        }
    }
    // your Prices POCO class becomes easier to read
    public class Prices
    {
        [LegacyName("0D")]    public decimal Today { get; set; }
        [LegacyName("1D")]    public decimal OneDay { get; set; }
        [LegacyName("6D")]    public decimal SixDay { get; set; }
        [LegacyName("10D")]   public decimal TenDay { get; set; }
        [LegacyName("12D")]   public decimal TwelveDay { get; set; }
        [LegacyName("1DA")]   public decimal OneDayAdjusted { get; set; }
        [LegacyName("6DA")]   public decimal SixDayAdjusted { get; set; }
        [LegacyName("10DA")]  public decimal TenDayAdjusted { get; set; }
        [LegacyName("100DA")] public decimal OneHundredDayAdjusted { get; set; }
    }
    // an extension method to ease the implementation:
    public static class PricesExtensions
    {
        public static void SetPriceByLegacyName(this Prices price, string name, decimal value)
        {
            if (price == null)
                throw new ArgumentException("Price cannot be null");
            foreach (PropertyInfo prop in price.GetType().GetProperties())
            {
                LegacyNameAttribute legNameAttribute = (LegacyNameAttribute)
                    Attribute.GetCustomAttribute(prop, typeof(LegacyNameAttribute));
                // set the property if the attribute matches
                if (legNameAttribute != null && legNameAttribute.Name == name)
                {
                    prop.SetValue(price, value, null);
                    break;   // nothing more to do
                }
            }
        }
    }
