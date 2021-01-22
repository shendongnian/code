    private bool IsNullableType(Type theType)
    {
        return (theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
    }
    // Create the columns based on the data in the album info - get by reflection
    var ai = new <your object without data>;
    Type t = ai.GetType();
    this.dataTable.TableName = t.Name;
    foreach (PropertyInfo p in t.GetProperties())
    {
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
        this.dataTable.Columns.Add(columnSpec);
    }
    this.dataGridView.DataSource = dataTable;
