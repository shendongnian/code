    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        string getDeviceDefaultLang = "fr";
        ChangeLanguage2(getDeviceDefaultLang);
    }
    
    private void ChangeLanguage2(string language)
    {
        try
        {
            ApplicationLanguages.PrimaryLanguageOverride = language;
            Frame.CacheSize = 0;
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            Frame.Navigate(this.GetType());
        }
        catch (Exception ex)
        {
            string exx = ex.ToString(); //getting System.NullReferenceException            
        }
    }
