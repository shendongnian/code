    public static T ConvertToBase<T>(Object extended) {
      if(extended == null) {
        throw new ArgumentException("Parameter extended was passed null!");
      }
      if(extended.GetType().BaseType != typeof(T)) {
        throw new ArgumentException($"Parameter extended does not inherit base type '{typeof(T).FullName}'");
      }
      PropertyInfo[] baseProperties = extended.GetType().BaseType.GetProperties();
      Object baseInstance = Activator.CreateInstance(extended.GetType().BaseType);
      foreach(PropertyInfo basePropertyInfo in baseProperties) {
        basePropertyInfo.SetValue(baseInstance, basePropertyInfo.GetValue(extended));
      }
      return (T)System.Convert.ChangeType(baseInstance, typeof(T));
    }
