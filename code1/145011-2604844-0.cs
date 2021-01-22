    // We want to do something like this:
    //    object o = "Hello"
    //    Type t = o.GetType(); 
    //
    // This is pseudo-code only:
    //    string s = A<t>.B(o); 
    
    string InvokeA(object o) {
      // Specify the type parameter of the A<> type
      Type genericType = typeof(A<>).MakeGenericType(new Type[] { o.GetType() });
      // Get the 'B' method and invoke it:
      object res = genericType.GetMethod("B").Invoke(new object[] { o });
      // Convert the result to string & return it
      return (string)res;
    }
