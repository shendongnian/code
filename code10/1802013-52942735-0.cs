    static void SetObjectProperty(object obj, string propertyPath, object value) {
        if(obj != null && obj.GetType() == typeof(LookUpEdit)) {
            string[] parts = propertyPath.Split('.');
            var rootInfo = typeof(LookUpEdit).GetProperty(parts[0], 
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            object root = rootInfo.GetValue(obj); // obtaining a root
            var nestedInfo = rootInfo.PropertyType.GetProperty(parts[1]);
            if(nestedInfo != null) 
                nestedInfo.SetValue(root, value, null); // using root object
        }
    }
