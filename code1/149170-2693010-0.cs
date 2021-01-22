      static void Main( string[] args )
      {
        Type type = typeof(MyClass);
        object o = Activator.CreateInstance(type);
      
        FieldInfo field = type.GetField("text", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(o, "www.domain.com");
        string text = (string)field.GetValue(o);
      
        Console.WriteLine(text);
        
      }
