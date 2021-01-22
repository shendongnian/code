    using System;
    using System.Collections.Generic;
    
    public class Foo {     
      Dictionary<Type, Object> _dict = new Dictionary<Type, Object>();
    
      public void Create(string myType, string myValue)
      {
          Type type = Type.GetType(myType);
          object value = Convert.ChangeType(myValue, type);
          _dict[type] = value;
      }
    
      public T GetValue<T>() { return (T)_dict[typeof(T)]; }
    }
    
    
    class Test
    {
        static void Main()
        {
            Foo foo = new Foo();
            
            // Populate with values
            foo.Create("System.Int32", "15");
            foo.Create("System.String", "My String");
            foo.Create("System.Boolean", "False");
            
            Console.WriteLine(foo.GetValue<int>());
            Console.WriteLine(foo.GetValue<string>());
            Console.WriteLine(foo.GetValue<bool>());
        }
    }
