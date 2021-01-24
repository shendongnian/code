    [Headers("Authorization: Basic")]
    public interface ITestApi
    {
        [Get("/api/test/{id}")]
        Task<string> GetTest([Header("Authorization")] string authorization, int id);
        [Get("/api/tests/")]
        Task<string> GetTests([Header("Authorization")] string authorization);
    }
    var username = "xxx";
    var password = "yyy";
    var authHeader = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
    var baseAddress = "https://my.test.net";
    var refitSettings = new RefitSettings()
    {
        AuthorizationHeaderValueGetter = () => Task.FromResult(authHeader)
    };
    ITestApi myApi = RestService.For<ITestApi>(baseAddress, refitSettings);
    int id = 123;
    var test= myApi.GetTest(id);
    var tests = myApi.GetTests();
