    public void Foo( int i, double d, param string[] values )
    {
        foreach( String s in values )
            Bar(s);
    }
    private Bar( String s )
    {
        //do something
    }
