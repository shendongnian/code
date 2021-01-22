    public static IndexWriter writer = new IndexWriter(myDir);
    
    public JsonResult SearchForStuff(string query)
    {
        IndexReader reader = writer.GetReader();
        IndexSearcher search = new IndexSearcher(reader);
        // do the search
    }
