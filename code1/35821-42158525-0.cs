    // remove "this" if not on C# 3.0 / .NET 3.5
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            Type Propiedad = null;
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                Propiedad = prop.PropertyType;
                if (Propiedad.IsGenericType && Propiedad.GetGenericTypeDefinition() == typeof(Nullable<>)) 
                {
                    Propiedad = Nullable.GetUnderlyingType(Propiedad);
                }
                table.Columns.Add(prop.Name, Propiedad);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
