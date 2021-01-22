    public static class Cloner
    {
        public static T clone<T>(this T item) 
        {
            FieldInfo[] fis = item.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            object tempMyClass = Activator.CreateInstance(item.GetType());
            foreach (FieldInfo fi in fis)
            {
                if (fi.FieldType.Namespace != item.GetType().Namespace)
                    fi.SetValue(tempMyClass, fi.GetValue(item));
                else
                {
                    object obj = fi.GetValue(item);
                    fi.SetValue(tempMyClass, obj.clone());
                }
            }      
            return (T)tempMyClass;
        }
    }
MyClass b = a.clone() as MyClass;
