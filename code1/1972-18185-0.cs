    public MyClass() 
        // no ref to base needed
    {
        // initialise stuff
    }
    public MyClass( int param1, string param2 )
        :this() //if not explicit this will be :base()
    {
    }
