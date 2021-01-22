    public static void Indented(this Log log, Action action)
    {
        log.Indent();
        try
        {
            action();
        }
        finally
        {
            log.Outdent();
        }
    }
