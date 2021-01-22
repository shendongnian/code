    public static SelectList ToSelectList<TEnum>(this TEnum self) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("self must be enum", "self");
            }
            Type t = typeof(TEnum);
            var values = from int e in Enum.GetValues(typeof(TEnum))
                         select new { ID = e, Name = Enum.GetName(typeof(TEnum), e) };
            return new SelectList(values, "ID", "Name", self);
        }
