    public class MyCustomException1 : ApplicationException {}
    public class MyCustomException2 : ApplicationException {}
    
    
    try
    {
     DoSomething();
    }
    catch(MyCustomException1 mce1)
    {
    }
    catch(MyCustomException2 mce2)
    {
    }
    catch(Exception ex)
    {
    }
    
