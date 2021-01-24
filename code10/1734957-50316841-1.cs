    var verificationResult = Models.User.VerifyLoginCredentials(username, password, out user);
    HttpContent responseContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user));
    if (verificationResult)
    {   
        return Ok(responseContent);
    }
