        public Nullable<T> GetNullableField<T>(this SqlDataReader reader, Int32 ordinal) where T : struct
        {
            var item = reader[ordinal];
            if (item == null)
            {
                return null;
            }
            if (item == DBNull.Value)
            {
                return null;
            }
            try
            {
                return (T)item;
            }
            catch (InvalidCastException ice)
            {
                throw new InvalidCastException("Data type of Database field does not match the IndexEntry type.", ice);
            }
        }
