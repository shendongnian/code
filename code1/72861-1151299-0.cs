    class CustomPostResult  // custom type for the results
    {
        public int? PostId { get; set; }
        public DateTime PostedDateUtcTime { get; set; }
    }
    
    //...
    
    string sqlQuery = @"SELECT DISTINCT TOP 1 'PostId' = ISNULL(RootPost,Id),
                       PostedDateTimeUtc FROM Post ORDER BY PostedDateTimeUtc DESC";
    
    IEnumerable<CustomPostResult> = dataContext.
                                            ExecuteQuery<CustomPostResult>(sqlQuery);
