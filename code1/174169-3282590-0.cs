    public string Method(Func<string> myFunc)
    {
        if(someBoolen)
            return "test";
    
        if(someOtherBoolean)
        {
            return "dfjakdsad";
        }
        else
        {
            string myStr = myFunc();
        }
    }
    Method(myEnum => getString(myEnum));
    Method(someInt => getString(someInt));
