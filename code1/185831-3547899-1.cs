    public string this[int index]
    {
        get
        {
            return myProperty[index];
        }
        set
        {
            myProperty[index] = value;
        }
    }
    public object this[object a, object b] // different input type(s) (and different return type)
    {
        get
        {
            // do other stuff
        }
    }
