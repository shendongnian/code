    double max = Searches.Max(x => (double)x.Count);
    List<SearchTagElement> processedTags = new List<SearchTagElement>();
    
    foreach (SearchRecordEntity sd in Searches)
    {
        var element = new SearchTagElement();                    
    
        double count = (double)sd.Count;
        double percent = (count / max) * 100;                    
    
        if (percent < 20)
        {
            element.TagCategory = "smallestTag";
        }
        else if (percent < 40)
        {
            element.TagCategory = "smallTag";
        }
        else if (percent < 60)
        {
            element.TagCategory = "mediumTag";
        }
        else if (percent < 80)
        {
            element.TagCategory = "largeTag";
        }
        else
        {
            element.TagCategory = "largestTag";
        }
    
        processedTags.Add(element);
    }
