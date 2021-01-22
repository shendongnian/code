    /// <summary>
        /// The method gets the SQL CE type name for use in SQL Statements such as CREATE TABLE
        /// </summary>
        /// <param name="dbType">The SqlDbType to get the type name for</param>
        /// <param name="size">The size where applicable e.g. to create a nchar(n) type where n is the size passed in.</param>
        /// <returns>The SQL CE compatible type for use in SQL Statements</returns>
        public static string GetSqlServerCETypeName(SqlDbType dbType, int size)
        {
            // Conversions according to: http://msdn.microsoft.com/en-us/library/ms173018.aspx
            bool max = (size == int.MaxValue) ? true : false;
            bool over4k = (size > 4000) ? true : false;
            if (size>0)
            {
                return string.Format(Enum.GetName(typeof(SqlDbType), dbType)+" ({0})", size); 
            }
            else
            {
                return Enum.GetName(typeof(SqlDbType), dbType);
            }
        }
