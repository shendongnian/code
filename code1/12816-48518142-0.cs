            /* This is a generic method that will convert any type of DataTable to a List 
             * 
             * 
             * Example :    List< Student > studentDetails = new List< Student >();  
             *              studentDetails = ConvertDataTable< Student >(dt);  
             *
             * Warning : In this case the DataTable column's name and class property name
             *           should be the same otherwise this function will not work properly
             */
            public static List<T> ConvertDataTable<T>(DataTable dt)
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            private static T GetItem<T>(DataRow dr)
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();
    
                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name == column.ColumnName)
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        else
                            continue;
                    }
                }
                return obj;
            }
