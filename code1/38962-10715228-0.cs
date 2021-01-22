    void CheckIfClassIsDecoratedWithMyOwnAttribute()
    {
        var instance = new MyClass();
        if (instance.GetType().GetCustomAttributes(typeof(MyOwnAttribute)))
        {
           //do whatever you want
        }
    }
