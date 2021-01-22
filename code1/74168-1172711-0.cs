    public void AddMainContentView(string moduleKey, string viewKey, object view)
    {
        Dictionary<string, object> viewDict = null;
        if (!MainContentViews.TryGetValue(moduleKey, out viewDict)) {
            viewDict = new Dictionary<string, object>();
            MainContentViews.Add(moduleKey, viewDict);
        }
        if (viewDict.ContainsKey(viewKey)) {
            viewDict[viewKey] = view;
        } else {
            viewDict.Add(viewKey, view);
        }
    }
