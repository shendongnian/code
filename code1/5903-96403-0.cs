    Type t = SomeOutlookObject.GetType();
    string messageClass = t.InvokeMember("MessageClass",
      BindingFlags.Public | 
      BindingFlags.GetField | 
      BindingFlags.GetProperty,
      null,
      SomeOutlookObject,
      new object[]{}).ToString();
    Console.WriteLine("\tType: " + messageClass);
