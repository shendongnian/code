    [TestMethod]
    public async Task TestGetUserInfoAsync()
    {
        //var tokenFile = TestUtils.GetLogFileLocation(nameof(this.TestRedeemTokensAsync2));
        var tokenFile = @"D:\Temp\TestLog\TestRedeemTokensAsync2.json";
        var accessToken = (JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(tokenFile))
            .access_token.ToString()) as string; // Here, cast this to string instead of keeping it as dynamic
    
        var result = await GoogleService.GetUserInfoAsync(this.systemConfig,
           accessToken);
        TestUtils.WriteLogFile(result);
    
        Assert.IsNotNull(result);
    }
