    MyClass myObj = null;
    try
    {
        myObj = new MyClass();
        myObj.SomeMthod(...);
    }
    finally
    {
        if(myObj != null)
        {
            ((IDisposable)myObj).Dispose();
        }
    } 
