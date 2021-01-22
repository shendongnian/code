    //create the query objects
    BooleanQuery query = new BooleanQuery();
    PhraseQuery q2 = new PhraseQuery();
    //grab the search terms from the query string
    string[] str = Sitecore.Context.Request.QueryString[BRAND_TERM].Split(' ');
    //build the query
    foreach(string word in str)
    {
      //brand is the field I'm searching in
      q2.Add(new Term("brand", word.ToLower()));
    }
            
    //finally, add it to the BooleanQuery object
    query.Add(q2, BooleanClause.Occur.MUST);
    
    //Don't forget to run the query
    Hits hits = searcher.Search(query);
