    void Recursive(int x)
    {
        // maintain the recursion path information
        path.Push(x);
        try
        {
            // do some stuff and recursively call the method
            Recursive(x + 6);
        }
        catch( RecursionException )
        {
            throw;
        }
        catch( Exception )
        {
            throw new RecursionException(path.ToString(), ex);
        }
        finally
        {
            // maintain the recursion path information
            path.Pop()
        }
    }
