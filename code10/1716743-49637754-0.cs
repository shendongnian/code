    private static IEnumerable<HttpCookie> GetAuthCookies(string loginUrl, string requestUrl, string username, string password)
    {
      var formContent = new Dictionary<string, string>();
      /* set these keys to the login form input's name values for username/password
         
         I.E.  If you have a login form like this
          <form>
            <input name="userName" id="userName_21342353465" type="text" />
            <input name="password" id="password_21342353465" type="password" />
          </form>
         then you would use "userName" and "password" for your keys below.
      */
      formContent.Add("userName", username);
      formContent.Add("password", password);
      // add any other required (or optional) fields in the form...
      var cookieContainer = new CookieContainer();
      var content = new FormUrlEncodedContent(formContent);
      var handler = new HttpClientHandler { CookieContainer = cookieContainer };
      var cookieCollection = new CookieCollection();
      using (var client = new HttpClient(handler))
      {
        using (var response = client.PostAsync(loginUrl, content).Result)
        {
          // Below is some getting the resposne string, you can use this to determine login status, may help with finding missing values in request
          //var responseString = response.Content.ReadAsStringAsync().Result;
        }
        foreach (var cookie in cookieContainer.GetCookies(new Uri(requestUrl)).Cast<Cookie>())
        {
          cookieCollection.Add(cookie);
        }
        foreach (var cookie in cookieCollection.Cast<Cookie>())
        {
          yield return new HttpCookie(cookie.Name, cookie.Value);
        }
      }
    }
