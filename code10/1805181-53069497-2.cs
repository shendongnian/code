    ...
     var re = Request;
    
    
                HttpResponseMessage response = new HttpResponseMessage();
                string action = "READ";
               
                //Check Authorization
                AuthorizationResponse authResponse = AuthProvider.CheckAuthorization(new AuthorizationRequest()
                {
                    SCode = UserUtils.GetUserSCode(User),
                    ConceptString = entity,
                    ActionString = action,
                    UserId = UserUtils.GetUserID(User),
                    ExtraParameters = new AuthorizationRequest.ExtraParamaters() { IdsOnly = false, Where = UserUtils.Where(re) }
                });
    ...
