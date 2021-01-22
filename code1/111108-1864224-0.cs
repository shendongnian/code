    RelationPredicateBucket filters = new RelationPredicateBucket();
    if (cat > 0)
        filters.Predicate.Add(Article.Fields.CategoryID == cat);
    if (userId > 0)
        filters.Predicate.Add(Article.Fields.UserID == userId);
    // And so on.
    var adapter = new DataAccessAdapter();
    var results = new EntityCollection<Article>(new ArticleFactory());
    adapter.FetchEntityCollection(results, filters);
