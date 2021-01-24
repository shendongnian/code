    public class ValuesController : Controller
        {
            private readonly IDynamoDbManager<MyModel> _dynamoDbManager;
            //This interface is used to setup dynamo db and connection to aws
            private static string dynamoDbTable = string.Empty;
    
            public ValuesController(IOptions<Dictionary<string, string>> appSettings, IDynamoDbManager<MyModel> dynamoDbManager)
            {
                _dynamoDbManager = dynamoDbManager;
                var vals = appSettings.Value;
                dynamoDbTable = vals["dynamoDbTable"];
            }
    
            [HttpGet("api/data")]
            public async Task<IActionResult> GetAllData(string type, string status)
            {
                var conditions = new List<ScanCondition>
                {
                    new ScanCondition("Type", ScanOperator.Equal, type),
                    new ScanCondition("Status", ScanOperator.Equal, status)
                };
                var result = await _dynamoDbManager.Get(conditions);
                var response = result.Select(_ => _.UpdatedBy.ToLower()).ToList();
                return Ok(response);
            }
    
            [HttpPost("api/save")]
            public async Task<IActionResult> SaveData([FromBody] List<MyModel> listData, string input, string name, string type)
            {
                foreach (var data in listData)
                {
                    //populating data here
                    await _dynamoDbManager.SaveAsync(data);
                }
                return Ok();
            }
        }
