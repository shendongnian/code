     Type type = typeof(Product); //or whatever the type is
     DataTable table = new DataTable();
     foreach(var prop in type.GetProperties())
     {
         Type colType = prop.PropertyType;
         if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
         {
             System.ComponentModel.NullableConverter nc = new System.ComponentModel.NullableConverter(colType);
             colType = nc.UnderlyingType;
         }
         table.Columns.Add(prop.Name, colType);
     }
