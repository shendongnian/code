    public static class ReflectionExtensions
    {
        public static void SetPropertyValue(this object Target,
            string PropertyName,
            object NewValue)
        {
            if (Target == null) return; //or throw exception
    
            System.Reflection.PropertyInfo prop = Target.GetType().GetProperty(PropertyName);
    
            if (prop == null) return; //or throw exception
    
            object value = prop.GetValue(Target, null);
    
            prop.SetValue(Target, NewValue, null);
        }
    }
