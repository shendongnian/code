    public List<Article> GetCat(int cat)
    
        {
            string qry = "select ap from Article a";
            if(cat > 0)
                 qry += " where a.categoryID = :cat";
            
            IQuery query = session.CreateQuery(qry).SetInt32("cat",cat);
            
            return query.List<Article>();
        }
