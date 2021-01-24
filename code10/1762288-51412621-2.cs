    TagQueryParams query = new TagQueryParams();
    List<Tag> list = new List<Tag>(), temp = null;
              
    query.Criteria.TagnameMask = "*";
              
    // simple query
    connection.ITags.Query(ref query, out list);
              
    // paged query
    list.Clear();
    query.PageSize = 100; // return at most 100 results per request
    while (connection.ITags.Query(ref query, out temp))
      list.AddRange(temp);
    list.AddRange(temp);
