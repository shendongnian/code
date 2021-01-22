    void DoStuff()
    {
        this.Recursive(1, this.RecursiveFunction1);
        this.Recursive(2, this.RecursiveFunction2);
    }
    bool RecursiveFunction1(int x)
    {
        bool continueRecursing = false;
        // do some stuff
        return continueRecursing;
    }
    bool RecursiveFunction2(int y)
    {
        bool continueRecursing = false;
        // do some other stuff here
        return continueRecursing;
    }
    
    private void Recursive(int x, Func<int, bool> actionPerformer)
    {
        // maintain the recursion path information
        path.Push(x);
        try
        {
            // recursively call the method
            if( actionPerformer(x) )
            {
                Recursive(x + 6, actionPerformer);
            }
        }
        catch( RecursionException )
        {
            throw;
        }
        catch( Exception ex )
        {
            throw new RecursionException(path.ToString(), ex);
        }
        finally
        {
            // maintain the recursion path information
            path.Pop();
        }
    }
