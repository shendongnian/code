    // This deterimines the maximum number of pages to show on each side of
    // the current page.
    int Range = 4
    // If the index is close to the beginning
    if(PageIndex <= Range + 1)
    {
        LowerCount = 1;
        HighCount = Math.Min(2*Range + 1, TotalPages);
    }
    // If the index is close to the end but not the beginning
    else if(TotalPages - PageIndex <= Range)
    {
        LowerCount = TotalPages - (2*Range);
        HighCount = TotalPages;
    }
    // If the index is in the middle.
    else
    {
        LowerCount = CurrentIndex - Range;
        HighCount = CurrentIndex + Range;
    }
  
