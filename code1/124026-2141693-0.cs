        public static int? GetNullableInt32(this IDataRecord dr, string fieldName)
        {
            return GetNullableInt32(dr, dr.GetOrdinal(fieldName));
        }
        public static int? GetNullableInt32(this IDataRecord dr, int ordinal)
        {
            return dr.IsDBNull(ordinal) ? null : (int?)dr.GetInt32(ordinal);
        }
