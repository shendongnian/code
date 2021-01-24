    public Task DoSomething(MyObjectType myObject)
    {
       // if myObject.IsValid is set initially, then uncomment the following line.
       // myObject.IsValid = true;
       while(myObject.IsValid)
       {
          // Call DB get some values
          var someData = _myRepository.Get(myObject.Id);
    
          // Process data
          someData.SomeValue = SomeFunction(someData.Property1, someData.Property2);
    
          // Not pretty code but I'm trying to set a few values for myObject here
          if(someData.SomeValue == null)
             MyUtils.PopulateErrorData(ref myObject, "Something went wrong!!!");
          if(!myObject.IsValid)
              break;
    
          // Save data -- When there's an error, I don't want to this this step
          await _myRepository.Save(someData);
       }
       
    }
