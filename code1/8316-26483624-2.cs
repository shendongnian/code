        Exception ex;
        try
        {
            throw new ArgumentException(); // for demo purposes; won't be caught.
            goto noCatch;
        }
        catch (ArgumentOutOfRangeException e) {
            ex = e;
        }
        catch (IndexOutOfRangeException e) {
            ex = e;
        }
        Console.WriteLine("Handle the exception 'ex' here :-)");
        // throw ex ?
    noCatch:
        Console.WriteLine("We're done with the exception handling.");
