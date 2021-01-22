    public static class Tracer
    {
    public static void Parameters(params object[] parameters)
    {
        #if DEBUG
        var jss = new JavaScriptSerializer();
        var stackTrace = new StackTrace();
        var paramInfos = stackTrace.GetFrame(1).GetMethod().GetParameters();
        var callingMethod = stackTrace.GetFrame(1).GetMethod();
        Debug.WriteLine(string.Format("[Func: {0}", callingMethod.DeclaringType.FullName + "." + callingMethod.Name + "]"));
        for (int i = 0; i < paramInfos.Count(); i++)
        {
            var currentParameterInfo = paramInfos[i];
            var currentParameter = parameters[i];
            Debug.WriteLine(string.Format("    Parameter: {0}", currentParameterInfo.Name));
            Debug.WriteLine(string.Format("    Value: {0}", jss.Serialize(currentParameter)));
        }
        Debug.WriteLine("[End Func]");
        #endif
      }
    }
