    var getString = await client.GetStringAsync("doLogin");
        foreach (var xar in Cookies.GetCookies(baseUrl).Cast<Cookie>())
        {
            if (xar.Name == "XSRF-TOKEN")Token = xar.Value;
        }
        client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", Token);
