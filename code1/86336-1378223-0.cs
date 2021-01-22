    public void Process(__arglist)
    {
        var iterator = new ArgIterator(__arglist);
        do
        {
            TypedReference typedReference = iterator.GetNextArg();
            Type type = __reftype(typedReference);
            if (type == typeof(int))
            {
                int value = __refvalue( typedReference,int);
                // value is an int
            }
            else if (type == typeof(string))
            {
                string value = __refvalue( typedReference,string);
                // value is a string
            }
            else if (type == typeof(double))
            {
                double value = __refvalue( typedReference,double);
                // value is a double
            }
            // etc.
        }
        while (iterator.GetRemainingCount() > 0);
    }
