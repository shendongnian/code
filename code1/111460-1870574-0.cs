    class CreateInvoker : IWebMethodInvoker
    {
       public SomeDataType Data {get; set;}
       public SomeOtherType Results {get; set;}
    
       public void Invoke()
       {
           Results = YourWebServiceMethod(Data);
       }
    }
