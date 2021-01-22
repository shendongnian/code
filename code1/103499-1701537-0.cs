    public static int BuggyFoo(int notZeroPlease)
    {
        return 5 / notZeroPlease;
    }
    public static int UseBuggyFoo(int userInput)
    {
        var myValue = userInput >> 2;
        try
        {
            var foo = BuggyFoo(myValue);
            return (foo + 5);
        }
        catch (Exception e)
        {
            e.Data["userInput"] = userInput;
            e.Data["myValue"] = myValue;
            throw;
        }
    }
    public static void Application_OnError(Exception e)
    {
        var sb = new StringBuilder();
        foreach (var k in e.Data.Keys)
        {
            sb.AppendFormat("Data[{0}] = {1}\n", k, e.Data[k])
        }
        Utilities.Logger.Log(sb.ToString(), e);
    }
