    static async Task GetAllUsers()
    {
        using (var client = GetHttpClient())
        {
            var response = await client.GetAsync(baseUrl + "api/v1/users");
        }
    }
