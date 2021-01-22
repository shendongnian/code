    StringBuilder sqlBuilder = new StringBuilder();
    foreach (PropertyInfo property in this.GetType().GetProperties())
    {
        string name = property.Name;
        // I believe you had a bug before - the properties being updated
        // would depend on the ordering of the properties - if it
        // ran into "TableName" first, it would exit early!
        // I *suspect* this is what you want
        if (name != cust.PKName && name != "TableName")
        {
            sqlBuilder.AppendFormat("{0} = @{0}, ", name);
        }
    }
    // Remove the trailing ", "
    if (sqlBuilder.Length > 0)
    {
        sqlBuilder.Length -= 2;
    }
