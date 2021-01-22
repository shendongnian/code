    object b = t["key"];
    Type typeB = b.GetType();
    // If ID is a property
    object value = typeB.GetProperty("ID").GetValue(b, null);
    // If ID is a field
    object value = typeB.GetField("ID").GetValue(b);
