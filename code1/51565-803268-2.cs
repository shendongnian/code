       public List<FieldInfo> FindFields(Type type, Type attribute)
        {
            var fields = new List<FieldInfo>();
            foreach (var field in type.GetFields(BindingFlags.Public |
                               BindingFlags.NonPublic |
                               BindingFlags.Instance))
            {
                if (field.IsDefined(attribute, true))
                {
                    fields.Add(field);
                }
    
            }
            return fields;
        }
