    protected void ReGenerateSessionId(string newsessionID)
    {
    	SessionIDManager manager = new SessionIDManager();
    	string oldId = manager.GetSessionID(Context);
    	string newId = manager.CreateSessionID(Context);
    	bool isAdd = false, isRedir = false;
    	manager.RemoveSessionID(Context);
    	manager.SaveSessionID(Context, newsessionID, out isRedir, out isAdd);
    
    	HttpApplication ctx = (HttpApplication)HttpContext.Current.ApplicationInstance;
    	HttpModuleCollection mods = ctx.Modules;
    	System.Web.SessionState.SessionStateModule ssm = (SessionStateModule)mods.Get("Session");
    	System.Reflection.FieldInfo[] fields = ssm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
    	SessionStateStoreProviderBase store = null;
    	System.Reflection.FieldInfo rqIdField = null, rqLockIdField = null, rqStateNotFoundField = null;
    
    	SessionStateStoreData rqItem = null;
    	foreach (System.Reflection.FieldInfo field in fields)
    	{
    		if (field.Name.Equals("_store")) store = (SessionStateStoreProviderBase)field.GetValue(ssm);
    		if (field.Name.Equals("_rqId")) rqIdField = field;
    		if (field.Name.Equals("_rqLockId")) rqLockIdField = field;
    		if (field.Name.Equals("_rqSessionStateNotFound")) rqStateNotFoundField = field;
    
    		if ((field.Name.Equals("_rqItem")))
    		{
    			rqItem = (SessionStateStoreData)field.GetValue(ssm);
    		}
    	}
    	object lockId = rqLockIdField.GetValue(ssm);
    
    	if ((lockId != null) && (oldId != null))
    	{
    		store.RemoveItem(Context, oldId, lockId, rqItem);
    	}
    
    	rqStateNotFoundField.SetValue(ssm, true);
    	rqIdField.SetValue(ssm, newsessionID);
    }
