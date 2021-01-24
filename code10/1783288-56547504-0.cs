        [Fact]
        public async Task Metrics()
        {
            var options = new FindOptions
            {
                Modifiers = new BsonDocument("$explain", true)
            };
            var queryable = await MongoDb.Collection.Find("{ Paid: false}", options).As<StatsBsonDocument>().ToListAsync(); // StatsBsonDocument BsonDocument  
            //Console.WriteLine(queryable.First());
            queryable.First().GetStats();            
        }
    public class StatsBsonDocument
    {
        public dynamic queryPlanner { get; set; }
        public ExecutionStats executionStats { get; set; }
        public dynamic serverInfo { get; set; }
        public void GetStats()
        {
            try
            {
                Console.WriteLine($"{queryPlanner.winningPlan.inputStage.stage}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"executionSuccess {executionStats.executionSuccess}, stage {queryPlanner.winningPlan.stage},");
            }
            Console.WriteLine($"{executionStats.nReturned} returned documents, {executionStats.executionTimeMillis}ms execution");
            Console.WriteLine($"{executionStats.totalKeysExamined} keys examined , {executionStats.totalDocsExamined} documents examined");
            Console.WriteLine($"index vs returned {(decimal)executionStats.totalKeysExamined / executionStats.nReturned}, " +
            $"scanned documents/returned {(decimal)executionStats.totalDocsExamined / executionStats.nReturned}");
            Console.WriteLine();
            // AND_SORTED stage or an AND_HASH stage. index intersection
        }
    }
    public class QueryPlanner
    {
        public dynamic plannerVersion;
        public string Namespace;
        public dynamic indexFilterSet;
        public dynamic parsedQuery;
        public dynamic winningPlan;
        public dynamic rejectedPlans;
    }
    public class ExecutionStats
    {
        public bool executionSuccess;
        public int nReturned;
        public int executionTimeMillis;
        public int totalKeysExamined;
        public int totalDocsExamined;
        public dynamic executionStages;
        public dynamic allPlansExecution;
    }
