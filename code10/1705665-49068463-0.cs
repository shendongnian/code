    readonly Dictionary<Tuple<Type, string, string>, int> _counters = 
         new Dictionary<Tuple<Type, string, string>, int>();
    bool IsCountExceeded(Exception ex)
    {
        // create your key with whatever properties you consider to 
        // be "unique"
        var key = Tuple.Create(ex.GetType(), ex.StackTrace, ex.Message);
        // increase counter 
        int counter;
        if (!_counters.TryGetValue(key, out counter))
        {
            counter = 1;
        }
        else
        {
            counter++;
        }
        _counters[key] = counter;
        return counter > Max;
    }
