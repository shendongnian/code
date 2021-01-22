    private void RecursiveFunction1(int x)
    {
        this.Recursive(x, delegate
        {
	    bool continueRecursing = false;
            // do some stuff
            return continueRecursing;
        });
    }
    private void RecursiveFunction2(int y)
    {
        this.Recursive(y, delegate
        {
	    bool continueRecursing = false;
            // do some other stuff here
            return continueRecursing;
        });
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
            path.Pop()
        }
    }
