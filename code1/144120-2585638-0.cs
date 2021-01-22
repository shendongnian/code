    public static class Extensions
    {
        public static void Awesome(this T myObject) where T : class
        {
            PropertyInfo[] properties = myObject.GetType().GetProperties();
            foreach(var info  in properties)
            {
                // if a string and null, set to String.Empty
                if(info.PropertyType == typeof(string))
                    info.SetValue(myObject, String.Empty, null);
            }
        }
    }
