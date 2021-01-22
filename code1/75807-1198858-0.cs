    private void ConvertTabItemObservableCollection()
    {
      Manager manager = this.container.Resolve<Manager>();
        foreach (var tabItem in TabItemObservableCollection)
        {
          manager.ObjectCollection.Add(tabItem);
        }
    }
