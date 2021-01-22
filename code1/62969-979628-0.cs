    public static ExecuteAndLog(this class1 obj)
    {
        logger.Write(obj.ToString());
        obj.Execute();
    }
