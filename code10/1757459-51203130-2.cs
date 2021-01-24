    static Lazy<HttpClient> client = new Lazy<HttpClient>(() => {
        string baseUrl = "http://m.ebay.com/itm/";
        var client = new HttpClient() {
            BaseAddress = new Uri(baseUrl)
        };
        return client;
    });
    private Task<string[]> GetWatchCountsAsync(string[] idlist) {
        string pattern = @"(?<=""defaultWatchCount""\s*:\s*)\d+";
        var tasks = idlist.Select(async id => {
            var input = await client.Value.GetStringAsync(id.Trim());
            string number = String.Empty;
            foreach (Match m in Regex.Matches(input, pattern)) {
                number += m.Value;
            }
            return number;
        });
        return Task.WhenAll(tasks);
    }
