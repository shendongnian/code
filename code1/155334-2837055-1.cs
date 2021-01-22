    private static Dictionary<string, bool> TicArticleExists
      (List<string> supplierIdents)   
    {
      using (TicDatabaseEntities db = new TicDatabaseEntities())   
      {   
        HashSet<string> queryResult = new HashSet(db.Articles
          .Where(a => supplierIdents.Contains(a.supplierArticleID))
          .Select(a => a.supplierArticleID));
    
        Dictionary<string, bool> result = supplierIdents
          .ToDictionary(s => s, s => queryResult.Contains(s));
    
        return result;
      }
    }
