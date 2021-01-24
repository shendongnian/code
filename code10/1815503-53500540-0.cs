    public async void MyMainMethod()
    {
       await DoSomethingAsync();
    
       //Here is a critical method that I want to execute only when 
         //DoSomethingAsync is finished
    
       CriticalStuff();
    }
    
    public async Task DoSomethingAsync()
    {
       //Do whatever
       await LongOperation();
       // Rest of the method that is executed when the long operation is 
        //finished.
    
    }
