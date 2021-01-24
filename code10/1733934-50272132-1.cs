    public static void Main(string[] args)
    {
        InnerMain(args).Wait();
    }
    private static async Task InnerMain(string[] args)
    {
       var accessToken = await GetAccessToken();
       var version =  await GetVersions(string token);
    }
