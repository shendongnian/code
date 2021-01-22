    public static void LoadFromReader<T>(this object source, SqlDataReader reader, string propertyName, string fieldName)
        {
            //Should check for nulls..
            Type t = source.GetType();
            PropertyInfo pi = t.GetProperty(propertyName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            object val = reader[fieldName];
            if (val == DBNull.Value)
            {
                val = default(T);
            }
            //Try to change to same type as property...
            val = Convert.ChangeType(val, pi.PropertyType);
            pi.SetValue(source, val, null);
        }
