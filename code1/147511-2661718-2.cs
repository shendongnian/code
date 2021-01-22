    public delegate long MyDelegate( int number );
    public void Method( IEnumerable<int> list, MyDelegate myDelegate )
    {
        foreach( var number in list )
        {
            myDelegate( number );
        }
    }
