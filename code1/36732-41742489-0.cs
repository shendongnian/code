     public static T Clone<T>(T original)
        {
            T newObject = (T)Activator.CreateInstance(original.GetType());
            foreach (var prop in original.GetType().GetProperties())
            {
                prop.SetValue(newObject, prop.GetValue(original));
            }
            return newObject;
        }
