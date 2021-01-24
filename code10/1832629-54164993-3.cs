    var searchResponse = client.Search<MyDocument>(s => s
        .Size(1000)
        .Scroll("30s")
    );
    while (searchResponse.Documents.Any())
    {
        foreach (var document in searchResponse.Documents)
        {
            // do something with this set of 1000 documents
        }
        // make an additional request
        searchResponse = client.Scroll<MyDocument>("30s", searchResponse.ScrollId);
    }
    // clear scroll id at the end
    var clearScrollResponse = client.ClearScroll(c => c.ScrollId(searchResponse.ScrollId));
