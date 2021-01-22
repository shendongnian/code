    foreach (var field in entity.GetType().GetFields())
    {
        var attributes = field.GetCustomAttributes(typeof(QuestionColumnAttribute), true);
        if (attributes.Length == 0)
            continue;
        var value = (string) reader[attributes[0].ColumnName];
        if (!string.IsNullOrEmpty(value))
            field.SetValue(entity, value);
    }
