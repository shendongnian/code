    //Assumes SomeObject implements IDisposable
    SomeObject obj = new SomeObject();
    try
    {
        // Do more stuff here.       
    }
    finally
    {
       if (obj != null)
       {
          ((IDisposable)obj).Dispose();
       }
    }
