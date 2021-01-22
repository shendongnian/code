       ISomeInterface sc = new SomeClass() as ISomeInterface;
       SomeOtherClass soc = new SomeOtherClass();
       foreach (PropertyInfo info in typeof(ISomeInterface)
                                         .GetProperties(BindingFlags.Instance
                                                         |BindingFlags.Public))
       {
           info.SetValue(soc,info.GetValue(sc,null),null);
       }
