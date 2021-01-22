    public static Array GetValues(this Enum enumType)
       {
           Type type = enumType.GetType();
           FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
           Array array = Array.CreateInstance(type, fields.Length);
           for (int i = 0; i < fields.Length; i++)
           {
               var obj = fields[i].GetValue(null);
               array.SetValue(obj, i);
           }
           return array;
       }
