    void method1() 
    { 
        String VIP = "test";
        WebClient proxy = new WebClient();
        proxy.OpenReadCompleted += proxy_OpenReadCompleted;
        String urlStr = "someurl/lookup?q=" + keyEntityName + "&fme=1&edo=1&edi=1";
        proxy.OpenReadAsync(new Uri(urlStr, UriKind.Relative), VIP);
    }    
    
    void proxy_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    { 
       String VIP = (string)e.UserState;
       // Do stuff that uses VIP.
    }
