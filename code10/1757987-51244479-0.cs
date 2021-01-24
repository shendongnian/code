    private void WriteLog(TraceRecord rec)
    {
    	if (rec.Exception == null)
    	{
    		string infoLog = string.Format("{0};{1};{3}", rec.Category, rec.Operator, rec.Operation, rec.Message);
    		log.Info(infoLog);
    	}
    	else
    	{
    		string errorLog = string.Format("{0};{1};{3}", rec.Category, rec.Operator, rec.Operation, rec.Message);
    		log.Error(errorLog, rec.Exception);
    	}
    }
