    public async static Task<string> GetString(string url)
    {
        HttpClient client = new HttpClient();
        // Way around to avoid Deadlock
        HttpResponseMessage message = await client.GetAsync(url).ConfigureAwait(false);
        return await message.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
