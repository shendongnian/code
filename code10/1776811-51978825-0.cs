     public HttpResponseMessage getNewsList(string topic, string district, string type,string count)
     {    
        jsonstring = Newtonsoft.Json.JsonConvert.SerializeObject(chatbotclass, Formatting.None);                           
        if (!string.IsNullOrEmpty(jsonstring))
        {
           var response = this.Request.CreateResponse(HttpStatusCode.OK);
           response.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");
           return response;
        }
           throw new HttpResponseException(HttpStatusCode.NotFound);    
    }
