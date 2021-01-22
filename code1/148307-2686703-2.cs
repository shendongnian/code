    public static Expression<Func<Document, bool>> SubQuery(string property, 
                                                             string targetValue)
            {
                var predicate = PredicateBuilder.True<User>();
                predicate = predicate.And<User>(Extensions.AdHoc<User>(property, targetValue));
    
                Expression<Func<Document, bool>> userSelector =
                                        doc => doc.Users
                                            .AsQueryable()
                                            .Any(predicate);
    
                var docParm = Expression.Parameter(typeof(Document), "appDoc");
                var body = Expression.Invoke(userSelector, docParm);
    
                var docPredicate = PredicateBuilder.True<Document>();
                docPredicate = docPredicate.And<Document>(Expression.Lambda<Func<Document, bool>>(body, docParm));
    
                return docPredicate;
            }
