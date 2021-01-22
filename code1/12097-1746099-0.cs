    [WebMethod]
    public string Foo(string arg1, XmlNode optarg2)
    {
        string arg2 = "";
        if (optarg2 != null)
        {
            arg2 = optarg2.Value;
        }
        ... etc
    }
