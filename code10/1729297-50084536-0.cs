    //member field which contains all the actual data
    List<Proxy> _proxies = new List<Proxy>();
    private void OnSomeTimerOrOtherTrigger()
    { 
          UIupdate();
    }
    
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
