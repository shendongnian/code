        public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");
            var values = from TEnum e in Enum.GetValues(typeof(TEnum)) select new { ID = (int)Enum.Parse(typeof(TEnum), e.ToString()), Name = e.ToString() };
            //var values = from TEnum e in Enum.GetValues(typeof(TEnum)) select new { ID = e, Name = e.ToString() };
            return new SelectList(values, "ID", "Name", enumObj);
        }
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, string selectedValue) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");
            var values = from TEnum e in Enum.GetValues(typeof(TEnum)) select new { ID = (int)Enum.Parse(typeof(TEnum), e.ToString()), Name = e.ToString() };
            //var values = from TEnum e in Enum.GetValues(typeof(TEnum)) select new { ID = e, Name = e.ToString() };
            if (string.IsNullOrWhiteSpace(selectedValue))
            {
                return new SelectList(values, "ID", "Name", enumObj);
            }
            else
            {
                return new SelectList(values, "ID", "Name", selectedValue);
            }
        }
