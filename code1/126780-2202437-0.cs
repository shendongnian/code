    Parallel.ForEach(chunkedIds, idChunk =>
        {
            ObjectContext context = new MyContext(connStr);//depending what's your config
                                                           // like, with or w/o conn string
            
            string delimChunk = string.Join(",", idChunk.Select(x => x.ToString()).ToArray());
            ObjectQuery<TElement> query = context.CreateQuery<TElement>("SELECT VALUE x FROM " + entitySetName + " AS x");
            query = query.Where("it." + fieldName + " IN {" + delimChunk + "}");
            chunkLists.Add(query.ToList());
        });
