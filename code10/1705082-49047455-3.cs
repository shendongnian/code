    private void ChangeLanguage2(string language)
    {
        try
        {
            ApplicationLanguages.PrimaryLanguageOverride = language;
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.CacheSize = 0;
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            rootFrame.Navigate(this.GetType());
        }
        catch (Exception ex)
        {
            string exx = ex.ToString(); //getting System.NullReferenceException            
        }
    }
