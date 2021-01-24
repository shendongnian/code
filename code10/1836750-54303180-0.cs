    public class AntennaItems
        {
            public int sector { get; set; }
            public int position { get; set; }
            public string qty { get; set; }
            public string model { get; set; }
    
    
            [FunctionName("AntennaSort")]
    public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    
                List<string> modelList = new List<string>();
    
                var jsonObj = JsonConvert.DeserializeObject<List<AntennaItems>>(requestBody);
    
                foreach (var elem in jsonObj)
                {
                    modelList.Add(elem.model);
                }
                return new OkObjectResult($"modelList = {modelList}");
            }
