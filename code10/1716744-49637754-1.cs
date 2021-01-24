        private static HttpContext GetHttpContext(string url)
    {
      var stringWriter = new StringWriter();
      var httpRequest = new HttpRequest("", url, "");
      var httpResponse = new HttpResponse(stringWriter);
      var httpContext = new HttpContext(httpRequest, httpResponse);
      var username = GetUserName();
      var password = GetPassword();
      var cookies = GetAuthCookies(LoginUrl, url, username, password);
      foreach (var cookie in cookies)
      {
        httpContext.Request.Cookies.Add(cookie);
      }
      return httpContext;
    }
    private const string LoginUrl = @"{{ Login's Post Back URL }}";
    private static string GetPassword()
    {
      var password = new StringBuilder();
      while (password.Length == 0)
      {
        Console.Write("Enter password: ");
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
          switch (key.Key)
          {
            case ConsoleKey.Backspace:
              if (password.Length > 0)
              {
                password.Remove(password.Length - 1, 1);
                Console.Write(key.KeyChar);
                Console.Write(' ');
                Console.Write(key.KeyChar);
              }
              break;
            default:
              password.Append(key.KeyChar);
              Console.Write('*');
              break;
          }
        }
        Console.WriteLine();
      }
      return password.ToString();
    }
    private static string GetUserName()
    {
      var username = string.Empty;
      while (string.IsNullOrWhiteSpace(username))
      {
        Console.Write("Enter username: ");
        username = Console.ReadLine();
      }
      return username;
    }
