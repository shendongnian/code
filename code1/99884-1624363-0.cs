    public static T Pairwise<T>(this IEnumerable<T> list)
    {
        T last;
        bool firstTime = true;
        foreach(var item in list)
        {
            if(!firstTime) 
                return(Tuple.New(last, item));
            else 
                firstTime = false; 
            last = item;
        }
    }
