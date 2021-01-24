    public void InvokeMethod(string methodName, Parameters parameters)
    {
        MethodInfo mi = typeof(JobsService).GetMethod(methodName);
        string s = (string)mi.Invoke(this, new[] { parameters });
    }
