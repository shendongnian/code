    [HttpPost]
    public IQueryable<Test> QueryTest(QueryTestRequest request)
    {
        var dbTest = db.Test.AsQueryable();
        return dbTest;
    }
    public class QueryTestRequest
    {
       public string Query {get; set;}
    }
