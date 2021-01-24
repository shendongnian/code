    public async Task<string> GetCardText(string cardName)
    {
        var path = System.Web.HttpContext.Current.Server.MapPath($"~/AdaptiveCards/{cardName}.json");
    
        if (!File.Exists(path))
            return string.Empty;
    
        using (var f = File.OpenText(path))
        {
            return await f.ReadToEndAsync();
        }
    }
