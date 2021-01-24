    async Task<List<string>> GetCompetitionAsync(string url)
    {
        using (var httpResponse = await httpClient.GetAsync(url))
        {
            string content = await httpResponse.Content.ReadAsStringAsync();
			return ExtractGroups(content);
		}
     }
