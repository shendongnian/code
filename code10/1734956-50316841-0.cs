    public static async Task<bool> VerifyCredentials(string userLogin, string password)
    {
        var value = new Dictionary<string, string>
        {
           { "userLogin", userLogin },
           { "password", password }
        };
        var test = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        var content = new StringContent(test, Encoding.UTF8, "application/json");
        var result = await WebApiHelper.Client.PostAsync("users/verifyLoginCredentials", content);
        if (result.IsSuccessStatusCode)
        {
            return true;
        }
        User resultContent = await result.Content.ReadAsAsync<User>();
        return false;
    }
