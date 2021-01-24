    class ResourceAttribute{
        string AttributeName;
        string Value;
        string DefaultValue;
        Public T GetValue<T>()
        {
          try {
              return Convert.ChangeType(number, typeof(T));
          }
          catch (InvalidCastException) {
             Console.WriteLine("Cannot convert");
             return default(T); // Or you can return your default value obj
          }
        }
    }
