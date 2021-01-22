    public int MyIndex
    {
        get
        {
            return (int)Session[ToString() + MethodInfo.GetCurrentMethod().Name.Substring(4)];
        }
    }
