    public Guid? Find (Dictionary<string, string> searchTerms)
    {
        if (searchTerms == null)
            throw new ArgumentNullException ("searchTerms");
        try
        {
                var directory = FSDirectory.Open (new DirectoryInfo (IndexRoot));
                if (!IndexReader.IndexExists (directory))
                    return null;
                var mainQuery = new BooleanQuery ();
                foreach (var pair in searchTerms)
                {
                    var parser = new QueryParser (
                        Lucene.Net.Util.Version.LUCENE_CURRENT, pair.Key, GetAnalyzer ());
                    var query = parser.Parse (pair.Value);
                    mainQuery.Add (query, BooleanClause.Occur.MUST);
                }
                var searcher = new IndexSearcher (directory, true);
                try
                {
                    var results = searcher.Search (mainQuery, (Filter)null, 10);
                    if (results.totalHits == 0)
                        return null;
                    return Guid.Parse (searcher.Doc (results.scoreDocs[0].doc).Get (ContentIdKey));
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (searcher != null)
                        searcher.Close ();
                }
        }
        catch
        {
                throw;
        }
    }
