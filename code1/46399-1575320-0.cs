    using System;
    using System.Reflection;
    class Program
    {
     private delegate void SetValue<T>(T value);
     private delegate T GetValue<T>();
     private class Foo
     {
      private string _bar;
    
      public string Bar
      {
       get { return _bar; }
       set { _bar = value; }
      }
     }
    
     static void Main()
     {
      Foo foo = new Foo();
      Type type = typeof (Foo);
      PropertyInfo property = type.GetProperty("Bar");
    
      // getter
      MethodInfo methodInfo = property.GetSetMethod();
      SetValue<string> setValue =
       (SetValue<string>) Delegate.CreateDelegate(typeof (SetValue<string>), foo, methodInfo);
      setValue("abc");
    
      // setter
      methodInfo = property.GetGetMethod();
      GetValue<string> getValue =
       (GetValue<string>) Delegate.CreateDelegate(typeof (GetValue<string>), foo, methodInfo);
      string myValue = getValue();
    
      // output results
      Console.WriteLine(myValue);
     }
    }
