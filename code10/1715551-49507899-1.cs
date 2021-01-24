    public void DoSomething(string optionalType, object opt1, object opt2)
    {
        var castObj = Convert.ChangeType(opt1, Type.GetType(optionalType)));
        var castObj2 = Convert.ChangeType(opt2, Type.GetType(optionalType)));
        int result = castObj .CompareTo(castObj2);
    }
