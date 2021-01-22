    // Create the columns based on the data in the album info - get by reflection
    var ai = new AlbumInfo();
    Type t = ai.GetType();
    dataTable.TableName = t.Name;
    foreach (PropertyInfo p in t.GetProperties())
    {
        // IF TYPE IS AN ARRAY (OR LIST) THEN ADD A COLUMN FOR EACH ELEMENT
        var columnSpec = new DataColumn();
        // If nullable get the underlying type
        Type propertyType = p.PropertyType;
        if (IsNullableType(propertyType))
        {
            var nc = new NullableConverter(propertyType);
            propertyType = nc.UnderlyingType;
        }
        columnSpec.DataType = propertyType;
        columnSpec.ColumnName = p.Name;
        dataTable.Columns.Add(columnSpec);
    }
    dataGridView.DataSource = dataTable;
