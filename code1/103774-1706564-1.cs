    public static class SqlDataReaderEx
    {
        public static int TryParse(SqlDataReader drReader, string strColumn, int nDefault)
        {
            int nOrdinal = drReader.GetOrdinal(strColumn);
            if (!drReader.IsDbNull(nOrdinal))
                return drReader.GetInt32(nOrdinal);
            else
                return nDefault;
        }
    }
