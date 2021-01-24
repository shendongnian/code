    object request = null;
    if (actionContext.Request.Method == HttpMethod.Post && "application/json".Equals(actionContext.Request.Content.Headers.ContentType.MediaType))
    {
    	var jsonContentTask = actionContext.Request.Content.ReadAsStringAsync();
    	Task.WaitAll(jsonContentTask);
        string jsonContent = jsonContentTask.Result;
    	//... other stuff
    }
