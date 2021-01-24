    public void OnGet() {
          var response = _client.PostAsync("account/login", new StringContent("")).Result;
          var status = response.StatusCode;
          if(status != HttpStatusCode.OK){
              //redirect to error page
          }
        }
