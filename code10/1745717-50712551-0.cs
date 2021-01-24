	public IAjaxResponse GetResponse<TOk, TFail>(string response)
	{
	    var responseJson = new Dictionary<string, object>();
	
	    object obj = null;
	
	    if ((string)responseJson["status"] == "ok")
	        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<TOk>(response);
	    else
	        obj = Newtonsoft.Json.JsonConvert.DeserializeObject<TFail>(response);
	
	    return (IAjaxResponse)obj;
	}
	
	public IAjaxResponse GetResponse<TOk>(string response)
	{
	    return (IAjaxResponse)Newtonsoft.Json.JsonConvert.DeserializeObject<TOk>(response);
	}
