    public MyFilterAttribute(string arg1 = null) : base(typeof(MyFilterImpl))
    {
        if(!string.IsNullOrEmpty(arg1))
        {
            this.Arguments = new object[] { arg1 };
        }
    }
