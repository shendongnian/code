    public bool MyProp
    {
        get { return (myProp = myProp ?? GetPropValue()).Value; }
    }
    private bool? myProp;
