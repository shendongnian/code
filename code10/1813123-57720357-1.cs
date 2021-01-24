    public static class TextFilters
    {
        public static string DaysFromNow(object input)
        {
            return DateTime.Now.AddDays(Convert.ToDouble(input)).ToString();
        }
    }
    Template.RegisterFilter(typeof(TextFilters));
