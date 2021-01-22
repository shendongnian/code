    static void RunInChildDomain()
    {
         AppDomain childDomain = AppDomain.CreateDomain("friendlyName");
         string parameterValue = "notmii";
         childDomain.SetData("parameter", parameterValue);
         childDomain.DoCallBack(PrintName);
    }
    static void PrintName()
    {
         string Name = Convert.ToString(AppDomain.CurrentDomain.GetData("parameter"));
         Console.WriteLine(Name);
    }
