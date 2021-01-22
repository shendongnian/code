    public void AddMainContentView(string moduleKey, string viewKey, object view)
    {
        if ( !_mainContentViews.ContainsKey(moduleKey))
        {
           Dictionary<string, object> newModule = new Dictionary<string, object>();
           newModule.Add(viewKey, view);
           _mainContentViews.Add(moduleKey, newModule);
        }
    }
