    lst = (from dataRow in csvData.AsEnumerable()
              select Converter<MyClass>.Fill(dataRow)).ToList();
    
    class Converter<T>
        {
            public static T Fill(DataRow Row)
            {
                
              Type typeParameterType = typeof(T);
             object retval = Activator.CreateInstance(typeParameterType);
             
                Dictionary<string, PropertyInfo> props = new Dictionary<string,PropertyInfo>();
                foreach (PropertyInfo p in retval.GetType().GetProperties())
                    props.Add(p.Name, p);
                foreach (DataColumn col in Row.Table.Columns)
                {
                    string name = col.ColumnName;
                    if (Row[name] != DBNull.Value && props.ContainsKey(name))
                    {
                        object item = Row[name];
                        PropertyInfo p = props[name];
                        if (p.PropertyType != col.DataType)
                            item = Convert.ChangeType(item, p.PropertyType);
                        p.SetValue(LogicObject, item, null);
                    }
                }
            return (T)retval ;
            }
        }
