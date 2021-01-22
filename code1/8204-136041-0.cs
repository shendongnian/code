    private static void MyMethod(string s, int x, int y)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            LogError(MethodBase.GetCurrentMethod(), ex, s, x, y);
        }
    }
    private static void LogError(MethodBase method, Exception ex, params object[] values)
    {
        ParameterInfo[] parms = method.GetParameters();
        object[] namevalues = new object[2 * parms.Length];
        string msg = "Error in " + method.Name + "(";
        for (int i = 0, j = 0; i < parms.Length; i++, j += 2)
        {
            msg += "{" + j + "}={" + (j + 1) + "}, ";
            namevalues[j] = parms[i].Name;
            if (i < values.Length) namevalues[j + 1] = values[i];
        }
        msg += "exception=" + ex.Message + ")";
        Console.WriteLine(string.Format(msg, namevalues));
    }
