    [OperationContract]
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
    public string LoadDetails()
    {
    	LogDetails objSubLog = new LogDetails ();
    	List<LogDetails> lstLogdetails;
    	DAL objDAL = new DAL();
    	lstLogdetails = objDAL.GetLog("ALL", objSubLog);
    	return lstLogdetails.ToJSON();
    }
