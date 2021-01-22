    public SessionStateStoreData GetSessionById(string sessionId)
    {
		HttpApplication httpApplication = HttpContext.ApplicationInstance;
		// Black magic #1: getting to SessionStateModule
		HttpModuleCollection httpModuleCollection = httpApplication.Modules;
		SessionStateModule sessionHttpModule = httpModuleCollection["Session"] as SessionStateModule;
		if (sessionHttpModule == null)
		{
			// Couldn't find Session module
			return null;
		}
		// Black magic #2: getting to SessionStateStoreProviderBase through reflection
        FieldInfo fieldInfo = typeof(SessionStateModule).GetField("_store", BindingFlags.NonPublic | BindingFlags.Instance);
		SessionStateStoreProviderBase sessionStateStoreProviderBase = fieldInfo.GetValue(sessionHttpModule) as SessionStateStoreProviderBase;
		if (sessionStateStoreProviderBase == null)
		{
			// Couldn't find sessionStateStoreProviderBase
			return null;
		}
		// Black magic #3: generating dummy HttpContext out of the thin air. sessionStateStoreProviderBase.GetItem in #4 needs it.
		SimpleWorkerRequest request = new SimpleWorkerRequest("dummy.html", null, new StringWriter());
		HttpContext context = new HttpContext(request);
		// Black magic #4: using sessionStateStoreProviderBase.GetItem to fetch the data from session with given Id.
		bool locked;
		TimeSpan lockAge;
		object lockId;
		SessionStateActions actions;
		SessionStateStoreData sessionStateStoreData = sessionStateStoreProviderBase.GetItem(
			context, sessionId, out locked, out lockAge, out lockId, out actions);
		return sessionStateStoreData;
    }
