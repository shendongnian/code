    public class SalesSummary
    {
        [XmlElement("MealPeriod1")]
        public List<MealPeriod> MealPeriod1 { get; set; }
        [XmlElement("MealPeriod1Sales")]
        public decimal MealPeriod1Sales { get; set; }
        [XmlElement("MealPeriod2")]
        public List<MealPeriod> MealPeriod2 { get; set; }
        [XmlElement("MealPeriod2Sales")]
        public decimal MealPeriod2Sales { get; set; }
        [XmlElement("MealPeriod3")]
        public List<MealPeriod> MealPeriod3 { get; set; }
        [XmlElement("MealPeriod3Sales")]
        public decimal MealPeriod3Sales { get; set; }
        [XmlElement("MealPeriod4")]
        public List<MealPeriod> MealPeriod4 { get; set; }
        [XmlElement("MealPeriod4Sales")]
        public decimal MealPeriod4Sales { get; set; }
    }
    public static class MealPeriodExtensions
    {
        public static string MealPeriodName(this IEnumerable<MealPeriod> mealPeriods)
        {
            if (mealPeriods == null)
                return null;
            return String.Concat(mealPeriods.Where(m => m.Items != null).SelectMany(m => m.Items).OfType<string>());
        }
        public static IEnumerable<T> MealPeriodItems<T>(this IEnumerable<MealPeriod> mealPeriods)
        {
            if (mealPeriods == null)
                return Enumerable.Empty<T>();
            return mealPeriods.Where(m => m.Items != null).SelectMany(m => m.Items).OfType<T>();
        }
    }
