    var FieldIds = new List<object>();
                var foo = new FirstClass();
                foo.Field1 = new Field() { FieldId = 1 };
                foo.Field2 = new Field() { FieldId = 2 };
                foo.Field3 = new Field() { FieldId = 3 };
                foo.Field4 = new Field() { FieldId = 4 };
                foo.Field5 = new Field() { FieldId = 5 };
    
    
                foreach (var prop in foo.GetType().GetProperties())
                {
                    if(prop.PropertyType == typeof(Field))
                    {
                        var field = prop.GetValue(foo, null) as Field;
    
                        FieldIds.Add(field.GetType().GetProperty("FieldId").GetValue(field,null));
                    }
                }
