    public DinnersViewModel(IDinnerCatalog catalog)
    {
        theCatalog = catalog;
        theCatalog.DinnerLoadingComplete +=
            new EventHandler<DinnerLoadingEventArgs>(
                  Dinners_DinnerLoadingComplete);
    }
    
    public void LoadDinners()
    {
        theCatalog.GetDinners();
    }
    
    void Dinners_DinnerLoadingComplete(
        object sender, DinnerLoadingEventArgs e)
    {
        // Fire Event on UI Thread
        View.Dispatcher.BeginInvoke(() =>
            {
                // Clear the list
                theDinners.Clear();
    
                // Add the new Dinners
                foreach (Dinner d in e.Results)
                    theDinners.Add(d);
    
                if (LoadComplete != null)
                    LoadComplete(this, null);
            });
    }
