    class Program
    {
      static void Main(string[] args)
      {
         UserDefinedClass udc = new UserDefinedClass();
         udc.UserProperty = "This is the property value";
         ClassTracer ct = new ClassTracer(udc);
         ct.TraceProperties();
         ct.CallMethod("UserFunction", "parameter 1 value");
      }
    }
    class ClassTracer
    {
      object target;
      public ClassTracer(object target)
      {
         this.target = target;
      }
      public void TraceProperties()
      {
         // Get a list of all properties implemented by the class
         System.Reflection.PropertyInfo[] pis = target.GetType().GetProperties();
         foreach (System.Reflection.PropertyInfo pi in pis)
         {
            Console.WriteLine("{0}: {1}", pi.Name, pi.GetValue(target, null));
         }
      }
      public void CallMethod(string MethodName, string arg1)
      {
         System.Reflection.MethodInfo mi = target.GetType().GetMethod(MethodName);
         if (mi != null)
         {
            mi.Invoke(target, new object[] { arg1 });
         }
      }
    }
    class UserDefinedClass
    {
      private string userPropertyValue;
      public string UserProperty
      {
         get
         {
            return userPropertyValue;
         }
         set
         {
            userPropertyValue = value;
         }
      }
      public void UserFunction(string parameter)
      {
         Console.WriteLine("{0} - {1}", userPropertyValue, parameter);
      }
    }
