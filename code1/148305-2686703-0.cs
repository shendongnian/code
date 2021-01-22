    var predicate = PredicateBuilder.True<Document>();
    predicate = predicate.And<Document>(User.SubQuery("UserName", "DAVER"));
    predicate = predicate.And<Document>(AdHoc<Document>("OwnerId", 1));
    
    var finDocs = docs.AsQueryable().Where(predicate).ToList();
