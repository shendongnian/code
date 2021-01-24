    public async Task<byte[]> GetAsync(string key)
    {
        async Task<byte[]> Action() => await this.Cache.GetAsync(key);
        return await this.Execute(Action);
    }
