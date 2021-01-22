    { // limits scope of myRes
        MyResource myRes= new MyResource();
        try
        {
            myRes.DoSomething();
        }
        finally
        {
            // Check for a null resource.
            if (myRes!= null)
                // Call the object's Dispose method.
                ((IDisposable)myRes).Dispose();
        }
    }
