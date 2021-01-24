    [Route("api/Entities/{entity}/filtered/")]
    public HttpResponseMessage GetFilter(string entity) {
      var request = Request;
      var headers = response.Headers;
      HttpResponseMessage response = new HttpResponseMessage();
      string action = "READ";
      var whrHeader = headers.Contains("whr") ? request.Headers.GetValues("whr").First() : ""
    
      AuthorizationResponse authResponse = AuthProvider.CheckAuthorization(new AuthorizationRequest() {
        SCode = UserUtils.GetUserSCode(User),
          ConceptString = entity,
          ActionString = action,
          UserId = UserUtils.GetUserID(User),
          ExtraParameters = new AuthorizationRequest.ExtraParamaters() {
            IdsOnly = false,
            Where = whrHeader
          }
      });
      if (authResponse.IsAuthorized) {
        //code
        response = Request.CreateResponse(HttpStatusCode.OK, json);
      } else {
        response = Request.CreateResponse(HttpStatusCode.Unauthorized);
      }
      return response;
    }
