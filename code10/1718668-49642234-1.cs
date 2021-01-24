    var argList = new object[] {"asd", 123, true };
    
    var argTypes = argList.Select(x => x.GetType())
                               .ToList();
             
    var testClass = new TestClass();
    
    var method = testClass.GetType()
                          .GetMethods()
                          .Where(m => m.GetCustomAttributes(typeof(MyAttribute), false)
                                                  .Length > 0)
                          .FirstOrDefault(x => x.GetParameters()
                                                  .Select(y => y.ParameterType)
                                                  .SequenceEqual(argTypes));
    
    if (method != null)
    {
       method.Invoke(testClass, argList);
    }
