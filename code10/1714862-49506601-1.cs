    private void SemanticZoom_ViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
    {
        if (e.IsSourceZoomedInView == false)
        {
            e.DestinationItem.Item = e.SourceItem.Item;
        }
    }
    
    
    private void ZoomedInListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        MySemanticZoom.IsZoomedInViewActive = false;
    }
    
    private void ZoomedOutListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        MySemanticZoom.IsZoomedInViewActive = true;
    }
