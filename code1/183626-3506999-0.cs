    private void SetSummary() 
    {
        int initialCount = 0;
        foreach(var item in _viewSource.View.SourceCollection)
        {
            initialCount++;
        }
        int filteredCount = 0;
        foreach (var item in _viewSource.View)
        {
            filteredCount++;
        }
    }
