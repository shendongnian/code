    /// <summary>
    /// Will return null if the CLR datetime will not fit in an SQL datetime
    /// </summary>
    /// <param name="datetime"></param>
    /// <returns></returns>
        public static DateTime? EnsureSQLSafe(this DateTime? datetime)
        {
            if (datetime.HasValue && (datetime.Value < (DateTime)SqlDateTime.MinValue || datetime.Value > (DateTime)SqlDateTime.MaxValue))
                return null;
            return datetime;
        }
