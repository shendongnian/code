    public void UpdateRecords<T>(T sender) 
       where T : SomeBaseClass_Or_SomeInterface_ThatDefinesMethod
    {
      sender = new T();
      sender.MethodInOtherClass( x, y );
    }
