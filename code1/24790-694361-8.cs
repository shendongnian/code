    namespace MyApp.Common
    {
        public static class MyExtensions{
            public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
                where TEnum : struct, IComparable, IFormattable, IConvertible
            {
                var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                    select new { Id = e, Name = e.ToString() };
                return new SelectList(values, "Id", "Name", enumObj);
            }
        }
    }
