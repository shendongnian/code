    public MyFilterAttribute(string arg1) : base(typeof(MyFilterImpl))
    {
        this.Arguments = new object[] { arg1 };
    }
    public MyFilterAttribute() : base(typeof(MyFilterImpl))
    {
    }
