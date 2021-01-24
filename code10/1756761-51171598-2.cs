        DataTable dataTable = new DataTable();
        //Get all the properties
        PropertyInfo[] Props = T1.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Defining type of data column gives proper data table 
            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name, type);
        }
        
        dataTable.Columns.Add(t2_column_name, t2_column_type);
        
        foreach (var item in JoinedResult)
        {
           var values = new object[Props.Length];
           for (int i = 0; i < Props.Length; i++)
           {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item.T1, null);
           }
           values[Props.Length] = item.T2;
           dataTable.Rows.Add(values);
       }
      
