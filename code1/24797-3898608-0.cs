    public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                           select new
                           {
                               ID = (int)Enum.Parse(typeof(TEnum), e.ToString()),
                               Name = e.ToString()
                           };
            return new SelectList(values, "ID", "Name", ((int)Enum.Parse(typeof(TEnum), enumObj.ToString())).ToString());
        }
