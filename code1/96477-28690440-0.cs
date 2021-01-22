     HttpCookie hc = new HttpCookie(cookieName);
     foreach (KeyValuePair<string, string> val in dic)
     {
       hc[val.Key] = val.Value;
      }
     hc.Expires = DateTime.Now.Add(TimeSpan.FromHours(20000));
     GetHttpResponse().Cookies.Add(hc);
