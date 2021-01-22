    public static DataTable ToDataTable<T>(  IList<T> data)
            {
            FieldInfo[] myFieldInfo;
            Type myType = typeof(T);
            // Get the type and fields of FieldInfoClass.
            myFieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public);
     
            DataTable dt = new DataTable();
            for (int i = 0; i < myFieldInfo.Length; i++)
                {
                FieldInfo property = myFieldInfo[i];
                dt.Columns.Add(property.Name, property.FieldType);
                }
            object[] values = new object[myFieldInfo.Length];
            foreach (T item in data)
                {
                for (int i = 0; i < values.Length; i++)
                    {
                    values[i] = myFieldInfo[i].GetValue(item);
                    }
                dt.Rows.Add(values);
                }
            return dt;
            }
    
    
    
