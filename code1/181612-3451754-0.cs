       _qualifiedTypeName = _context.DefaultContainerName + "." + _baseTypeName;
        Type baseType = GetBaseType(typeof(T));
        _baseTypeName = baseType.Name.ToString();
        PropertyInfo[] entityProperties = baseType.GetProperties();
        List<string> keyList = new List<string>();
        foreach (PropertyInfo prop in entityProperties) 
        {
          object[] attrs = prop.GetCustomAttributes(false);
          foreach (object obj in attrs)                
          {
            if (obj.GetType() == typeof(EdmScalarPropertyAttribute))
            {
              EdmScalarPropertyAttribute attr = (EdmScalarPropertyAttribute)obj;
              if (attr.EntityKeyProperty) keyList.Add(prop.Name);
             }
           }
        }
        if (keyList.Count > 0)
        {
          _keyName = keyList[0];
        }
        EntityKey key = new EntityKey(_qualifiedTypeName, keyName, keyValue);
