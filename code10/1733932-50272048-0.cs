    public async Task<string> GetAccessToken(){
        return "token";
    }
    
    public async Task<string> GetVersions(string token){
        var version = await GetVersionsFromServer(token); 
    
        if(version.HasNextVersion) 
           version = await GetVersions();
       // you need to return something!
       return version;
    }
    
    private async Task DoWork() {
      var accessToken = await GetAccessToken();
      var version =  await GetVersions(accessToken);
    }
    string Main(){
     DoWork().Wait();
    }
