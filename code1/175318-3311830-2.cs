    private static Dictionary<string, BookmarkEnd> FindBookmarks(OpenXmlElement documentPart, Dictionary<string, BookmarkEnd> results = null, Dictionary<string, string> unmatched = null )
    {
        results = results ?? new Dictionary<string, BookmarkEnd>();
        unmatched = unmatched ?? new Dictionary<string,string>();
        foreach (var child in documentPart.Elements())
        {
            if (child is BookmarkStart)
            {
                var bStart = child as BookmarkStart;
                unmatched.Add(bStart.Id, bStart.Name);
            }
            if (child is BookmarkEnd)
            {
                var bEnd = child as BookmarkEnd;
                foreach (var orphanName in unmatched)
                {
                    if (bEnd.Id == orphanName.Key)
                        results.Add(orphanName.Value, bEnd);
                }
            }
            FindBookmarks(child, results, unmatched);
        }
        return results;
    }
