    public int DoStuff()
    {
        var result = 0; //put default result here
        // Do stuff
        if (foo == 0)
        {
            throw new Exception(...);
        }
        else if (foo == 1)
        {
            // Do other stuff
            result = ...;
        }
        else
        {
            ExitApp("Something borked");
        }
        return result;
    }
