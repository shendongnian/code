    public void ChangedLanguage(object source, EventHandlerBase e)
    {
            if (e.GetStatus())
            {
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
                Frame.Navigate(this.GetType());
                
            }
    }
