    public static class Extensions
    {
        public static void Awesome<T>(this T myObject) where T : class
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach(var info  in properties)
            {
                // if a string and null, set to String.Empty
                if(info.PropertyType == typeof(string))
                    info.SetValue(myObject, String.Empty, null);
            }
        }
    }
