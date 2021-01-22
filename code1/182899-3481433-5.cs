    foreach (var field in entity.GetType().GetFields())
    {
        var attributes = field.GetCustomAttributes(typeof(QuestionColumnAttribute), true);
        if (attributes.Length == 0)
            continue;
        object value = reader[attributes[0].ColumnName];
        if (!(value is DBNull))
            field.SetValue(entity, value.ToString());
    }
