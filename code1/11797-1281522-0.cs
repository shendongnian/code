    interface IFoo
    {
       string Message {get;}
    }
    ...
    IFoo obj = new IFoo("abc");
    Console.WriteLine(obj.Message);
