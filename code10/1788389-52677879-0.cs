    //payload am sending to the api	
       RequestPayload res = new RequestPayload();
       res.appid = appid;
       res.data = data;
       res.method = "Login";
    
       //convert to json object
       var MySerializedObject =  JsonConvert.SerializeObject(res);
       
       string APIUrl = ""http://142.168.20.15:8021/RouteTask";
    
       //create basic .net http client
       HttpClient client = new HttpClient();
       client.BaseAddress = new Uri(APIUrl);
       
       // this was required in the header of my request, 
       // you may not need this, or you may need to adjust parameter
       //("RequestSource","Web") or you own custom headers
       client.DefaultRequestHeaders.Add("RequestSource", "Web");
        // this class is custom, you can leave it out
       connectionService = new ConnectionService();
      //check for internet connection on users device before making the call
      if (connectionService.IsConnected)
        {
		   //make the call to the api
            HttpResponseMessage response = await 
            client.PostAsJsonAsync(ApiConstants.APIDefault, res);
            if (response.IsSuccessStatusCode)
                {
                    string o = response.Content.ReadAsStringAsync().Result;
                    dynamic payload = JsonConvert.DeserializeObject(o);
                    string msg = payload["valMessage"];
                    resp.a = true;
                    resp.msg = payload["responseDescription"];
                }
            else
                {
                    string o = response.Content.ReadAsStringAsync().Result;
                    dynamic payload = JsonConvert.DeserializeObject(o);
                    resp.a = false;
                    resp.msg = payload["response"];
                }
        }
  
