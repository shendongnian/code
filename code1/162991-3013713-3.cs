    string str = "hello world";
    if(typeof(Object).IsAssignableFrom(str.GetType()))
    {
        //instances of type String can be assigned to instances of type Object.
    }
    if(typeof(Object).IsAssignableFrom(typeof(string)))
    {
        //instances of type String can be assigned to instances of type Object.
    }
