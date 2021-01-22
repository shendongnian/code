    class MyException : Exception
    {
    	...bla bla...
    
    }
    
    class OtherEx: notImplementedException
    {
    	...foo foo..
    	
    }
    
    try
    {
    
    }
    catch(MyException ex)
    {
    	Console.WriteLine("Is mine !");
    
    }
    catch(OtherEx ex)
    {
    	Console.WriteLine("Is other !");
    
    }
    catch(Exeception ex)
    {
    	Console.WriteLine("Is anything else !");
    
    }
