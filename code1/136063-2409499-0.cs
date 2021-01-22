    public IEnumerable<Document> Search(
        Expression<Func<Document, bool>> predicate) 
    {
        using (db = new DocumentDataContext())
        {
            return db.Documents.Where(predicate).ToArray();
        }
    }
