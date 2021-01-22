    string loginResponseText = new StreamReader(loginResponse.GetResponseStream()).ReadToEnd();
    CookieContainer cookies = new CookieContainer();
    foreach (string ln in loginResponseText.Split('\n'))
    {
        if (!ln.Contains("=")) continue;
        string tId = ln.Substring(0, ln.IndexOf('=')).Trim();
        string tVal = ln.Substring(ln.IndexOf('=') + 1).Trim();
        cookies.Add(new Cookie(tId, tVal, "/", "www.google.com"));
    }
