    private FilterDefinition<ViewedContent> GetDocumentIdsFilter(IEnumerable<string> doc_ids, IEnumerable<string> sec_ids)
    {
        var filterBuilder = Builders<ViewedContent>.Filter;
        var query = filterBuilder.Empty; // start with an empty query
        using (var docIdsEnumerator = doc_ids.GetEnumerator())
        {
            using (var secIdsEnumerator = sec_ids.GetEnumerator())
            {
                // loop through both enumerables
                while (docIdsEnumerator.MoveNext() && secIdsEnumerator.MoveNext())
                {
                    var docId = docIdsEnumerator.Current;
                    var secId = secIdsEnumerator.Current;
                    
                    // we chain up all the combinations using an $or with a nested $and that represents the two constituents of your ids
                    query = filterBuilder.Or(query, filterBuilder.And(
                        filterBuilder.Eq(x => x.doc_id, docId),
                        filterBuilder.Eq(x => x.sec_id, secId)));
                }
            }
        }
        return query;
    }
