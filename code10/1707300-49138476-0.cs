    class TokenJsonResult{
      public string token {get;set;}
    }
    
    var parsedJson = JsonConvert.DeserializeObject<TokenJsonResult>(json);
    var token = parsedJson.token;
