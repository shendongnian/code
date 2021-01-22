    static void Main(string[] args)
    {
        AppDomain domain = AppDomain.CreateDomain("Domain666");
        domain.SetData("str", "abc");
        domain.DoCallBack(MyNewAppDomainMethod);
        string str = domain.GetData("str") as string;
        Debug.Assert(str == "def");
    }
    
    static void MyNewAppDomainMethod()
    {
        string str = AppDomain.CurrentDomain.GetData("str") as string;
        Debug.Assert(str == "abc");
        AppDomain.CurrentDomain.SetData("str", "def");
    }
