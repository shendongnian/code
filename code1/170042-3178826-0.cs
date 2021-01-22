    private object padLock = new object();  // 1-to-1 with _ConditionalOrderList
    
    if (Monitor.TryEnter(padLock))
    {
        \\ cancel other orders
        return true;
    }
    else
    {
       return false;
    }
