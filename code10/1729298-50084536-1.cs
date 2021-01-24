    //member field which contains all the actual data
    List<Proxy> _proxies = new List<Proxy>();
    //this is some trigger: it might be an ellapsed event of a timer or something
    private void OnSomeTimerOrOtherTrigger()
    { 
          UIupdate();
    }
    
    //just a helper function
    private void UIupdate
    {
        var local = _proxies.ToList(); //ensure static encapsulation 
        proxiesDataGridView.BeginInvoke(new Action(() => 
        {    
             //someway to add *new ones* to UI
        }));
    }
    private void Site_ProxyScraped(object sender, Proxy proxy)
    {
        Task.Run(async () =>
        {
            proxy.IsValid = await proxy.TestValidityAsync(judges[0]);
            //add to list
            _proxies.Add(proxy);
        });
    }
