    //Assumes SomeObject implements IDisposable
    SomeObject obj = new SomeObject();
    try
    {
        // Do more stuff here.       
    }
    finally
    {
       obj.Dispose();
    }
