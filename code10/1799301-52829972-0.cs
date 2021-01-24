    public partial class Response
    {
        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public Employee[] Data { get; set; }
    }
    public partial class Employee
    {
        [JsonProperty("empName")]
        public string EmpName { get; set; }
        [JsonProperty("empCode")]
        public long EmpCode { get; set; }
        [JsonProperty("empId")]
        public string EmpId { get; set; }
    }
 
    var ResponseJSON= JsonConvert.DeserializeObject<Response>(normalJson);
