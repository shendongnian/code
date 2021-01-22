        public static int Int32(this SqlDataReader r, int ord)
        {
            var t = r.GetSqlInt32(ord);
            return t.IsNull ? default(int) : t.Value;
        }
