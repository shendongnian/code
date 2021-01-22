    public void RunBusinessRule(MyCustomType customType)
    {
        if (customType.CustomBoolProperty == false)
        {
            throw new Exception("This is obviously false or possibly null lets throw up an error.");
        }
        DoSomething(); 
    }
