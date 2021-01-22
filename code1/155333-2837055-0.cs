    using (TicDatabaseEntities db = new TicDatabaseEntities()) 
    {
      bool result = db.Articles
        .Any(a => a.supplierArticleID.Equals(supplierIdent));
    
      return result;
    }
