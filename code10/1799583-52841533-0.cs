    [Fact]
    public void ShouldParseClass()
    {
        var result = JsonConvert.DeserializeObject<List<SOClass>>("[{\r\n\t'variable1': [{0:'somename'}],\r\n\r\n\t'variable2': 'xxx'\r\n}]");
        Assert.True(result.First().variable1[0]["0"] == "somename");
    }
    public class SOClass
    {
        public string variable2 { get; set; }
        public List<dynamic> variable1 { get; set; }
    }
