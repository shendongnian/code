  public static class PropertyExtension{
       
        public static void SetValue(this object obj, string propName, object value)
        {
            obj.GetType().GetProperty(propName).SetValue(obj, value, null);
        }
    }
