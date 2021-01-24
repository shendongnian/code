    public HttpResponseMessage GetUsers()
    {
        var users = _service.GetUsers()
        var model = new UserResponse(users);
    
        var json = JsonConvert.SerializeObject(model);
        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(json , Encoding.UTF8, "application/json");
        return response
    }
