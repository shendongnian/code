    public void setMyProperty(int value, Object caller)
    {
        if(caller is MyManagerClass)
        {
            MyProperty = value;
        }
    }
