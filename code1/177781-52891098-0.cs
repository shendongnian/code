        public static string ToCsvString<T>(T obj)
        {
            var fields =
                from mi in typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                where new[] { MemberTypes.Field, MemberTypes.Property }.Contains(mi.MemberType)
                let orderAttr = (ColumnOrderAttribute)Attribute.GetCustomAttribute(mi, typeof(ColumnOrderAttribute))
                select mi;
            return QuoteRecord(FormatObject(fields, obj));
        }
        public static string GetCsvHeader<T>(T obj)
        {
            var fields =
                from mi in typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                where new[] { MemberTypes.Field, MemberTypes.Property }.Contains(mi.MemberType)
                let orderAttr = (ColumnOrderAttribute)Attribute.GetCustomAttribute(mi, typeof(ColumnOrderAttribute))
                select mi;
            return QuoteRecord(fields.Select(f => f.Name));
        }
