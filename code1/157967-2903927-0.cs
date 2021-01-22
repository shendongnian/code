    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        SetUpProviderConnection();
    }
    private bool SetUpProviderConnection()
    {
        bool connectionCreated = false;
        WebPartManager manager = WebPartManager.GetCurrentWebPartManager(Page);
        foreach (System.Web.UI.WebControls.WebParts.WebPart webPart in manager.WebParts)
        {
            BaseWebPart provider = webPart as BaseWebPart;
            if (provider != null && (provider != this))
            {
                if (manager is Microsoft.SharePoint.WebPartPages.SPWebPartManager)
                {
                    SPWebPartManager spManager = SPWebPartManager.GetCurrentWebPartManager(Page) as SPWebPartManager;
                    spManager.SPWebPartConnections.Add(new SPWebPartConnection()
                    {
                        ID = string.Format("WebPartConnection{0}{1}", this.ID, provider.ID),
                        ConsumerID = this.ID,
                        ConsumerConnectionPointID = "WebPartConnectableConsumer",
                        ProviderID = provider.ID,
                        ProviderConnectionPointID = "WebPartConnectableProvider"
                    });
                }
                else
                {
                    manager.StaticConnections.Add(new WebPartConnection()
                    {
                        ID = string.Format("WebPartConnection{0}{1}", this.ID, provider.ID),
                        ConsumerID = this.ID,
                        ConsumerConnectionPointID = "WebPartConnectableConsumer",
                        ProviderID = provider.ID,
                        ProviderConnectionPointID = "WebPartConnectableProvider"
                    });
                }
                connectionCreated = true;
            }
        }
        return connectionCreated;
    }
