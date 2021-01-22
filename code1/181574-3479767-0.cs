    public override void FeatureActivated(SPFeatureReceiverProperties properties)
    {
        var webApp = (SPWebApplication)properties.Feature.Parent;
        webApp.WebService.ApplyApplicationContentToLocalServer();
    }
