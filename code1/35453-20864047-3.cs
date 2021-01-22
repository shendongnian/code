    public void DoWork(string foo)
    {
        using (FnTraceWrap fnTrace = new FnTraceWrap())
        {
            fnTrace.TraceMessage("Doing work on {0}.", foo);
            /*
            code ...
            */
        }
    }
