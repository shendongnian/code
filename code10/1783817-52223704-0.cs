    public System.Net.Http.HttpResponseMessage GetServiceStatus()
    {
        ......
        string sJsonRet = JsonHelper.Serialize(rspMsg);
        System.Net.Http.HttpResponseMessage resp = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
        resp.Content = new System.Net.Http.StringContent(sText,System.Text.Encoding.UTF8, "text/plain");
			return resp;        
    }
