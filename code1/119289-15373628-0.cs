    void Regions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            foreach (var o in e.NewItems)
            {
                IRegion region = o as IRegion;
                if (region != null && region.Name == RegionNames.NavigationRegion)
                {
                    region.SortComparison = CompareNavigatorViews;
                }
            }
        }
    }
