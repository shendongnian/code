    FieldInfo[] fields = this.GetType().GetFields();
    foreach (FieldInfo field in fields.Where(f => f.Name == "_person"))
    {
       Object value = field.GetValue(this);
       PropertyInfo property = value.GetType().type.GetProperty("Name");
       property.SetValue(value, "new name", null);
    }
