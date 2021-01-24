    // If the index is close to the beginning
    if(PageIndex <= 5)
    {
        LowerCount = 1;
        HighCount = Math.Min(9, TotalPages);
    }
    // If the index is close to the end
    else if(TotalPages - PageIndex <= 4)
    {
        LowerCount = TotalPages - 8;
        HighCount = TotalPages;
    }
    // If the index is in the middle.
    else
    {
        LowerCount = CurrentIndex - 4;
        HighCount = CurrentIndex + 4;
    }
  
