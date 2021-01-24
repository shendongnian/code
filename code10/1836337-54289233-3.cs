    public Type IdentifyCorrectType()
    {
        var identifyingCondition = GetCorrectType();// returns 1,2,3...
        switch(identifyingCondition)
        {
            case 1:
                return typeof(MyType1);
            case 2:
                return typeof(MyType2);
            case 3:
                return typeof(MyType3);
            default:
                return null;
        }
    }
