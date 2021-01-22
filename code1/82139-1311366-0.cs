    var childElements = initialCollection.Where(e => e.ParentID != null)
                                         .ToLookup(e => e.ParentID);
    foreach (MyElement e in rootElements)
    {
        if (childElements.Contains(e.ID))
        {
            e.Children.AddRange(childElements[e.ID]);
        }
    }
