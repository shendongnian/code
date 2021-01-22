    public bool IsGreaterThanNow(DateTime timestamp)
    {
        return DateTime.Now < timestamp;
    }
    
    public bool IsLessThanNow(DateTime timestamp)
    {
        return DateTime.Now > timestamp;
    }
    Foo f1 = IsGreaterThanNow;
    Foo f2 = IsLessThanNow;
    Foo fAll = f1 + f2;
