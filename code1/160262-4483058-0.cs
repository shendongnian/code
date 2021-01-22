    public Bar(Log log)
    {
       Contract.Requires<ArgumentNullException>(log != null);
       log.Lines.Add(...);
       // ...
    }
