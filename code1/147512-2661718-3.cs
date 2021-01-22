    public void Method( IEnumerable<int> list, Func<int, long> myDelegate )
    {
        foreach( var number in list )
        {
            myDelegate( number );
        }
    }
