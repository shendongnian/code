    public void int DoStuff()
    {
        // Do stuff
        if (foo == 0)
        {
            throw new Exception(...);
        }
        else if (foo == 1)
        {
            // Do other stuff
            return ...;
        }
        else
        {
            ExitApp("Something borked");
            throw new UnreachableException();
        }
    }
