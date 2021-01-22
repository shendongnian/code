    public static void DeleteCookie(
      HttpRequest request, HttpResponse response, string name)
    {
      if (request.Cookies[name] == null) return;
      var cookie = new HttpCookie(name) {Expires = DateTime.Now.AddDays(-1d)};
      response.Cookies.Add(cookie);
    }
