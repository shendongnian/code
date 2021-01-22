    protected bool isCommission
    public bool IsCommission
    {
    get { return isCommission; }
    set { isCommission = value; }
    }
    public bool IsFee
    {
    get { return !isCommission; }
    set { isCommission = !value; }
    }
