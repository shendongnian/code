    List<T> GetRelatedItemsList<T> (T item) where T : IOurMediaItem // I used an interface here because I like them :P - it can also be a class.
    {
        if (item.TagCount == 1)
        {
            // Get related items with the same tag and based on some keywords in title
        }
        else
        {
            // First: Get all items with exactly the tags
            // Second Get all items with relating title and append it to the list
        }
    }
