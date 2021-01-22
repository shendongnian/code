     public static DependencyProperty GetDependencyProperty(Type type, string name)
     {
         FieldInfo fieldInfo = type.GetField(name, BindingFlags.Public | BindingFlags.Static);
         return (fieldInfo != null) ? (DependencyProperty)fieldInfo.GetValue(null) : null;
     }
