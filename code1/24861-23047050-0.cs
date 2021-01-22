    public static class EnumHtmlHelper
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, Dictionary<int, string> customLabels)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = customLabels.First(x => x.Key == Convert.ToInt32(e)).Value.ToString() };
    
            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
