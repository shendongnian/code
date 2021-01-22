    public static class DataTableEnumerate
    {
        public static void Fill<T> (this IEnumerable<T> Ts, ref DataTable dt) where T : class
        {
            //Get Enumerable Type
            Type tT = typeof(T);
            //Get Collection of NoVirtual properties
            var T_props = tT.GetProperties().Where(p => !p.GetGetMethod().IsVirtual).ToArray();
            //Fill Schema
            foreach (PropertyInfo p in T_props)
                dt.Columns.Add(p.Name, p.GetMethod.ReturnParameter.ParameterType.BaseType);
            //Fill Data
            foreach (T t in Ts)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo p in T_props)
                    row[p.Name] = tT.GetProperty(p.Name).GetValue(t);
                dt.Rows.Add(row);
            }
        }
    }
