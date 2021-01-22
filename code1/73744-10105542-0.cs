        public static List<T> GetItemsList<T>(this int enums) where T : struct, IConvertible
        {
            if (!typeof (T).IsEnum)
            {
                throw new Exception("Type given must be an Enum");
            }
            return (from int item in Enum.GetValues(typeof (T))
                    where (enums & item) == item
                    select (T) Enum.Parse(typeof (T), item.ToString(new CultureInfo("en")))).ToList();
        }
