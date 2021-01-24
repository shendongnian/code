    public async Task DeleteAsync(string key)
    {
        Task Action() => this.Cache.DeleteAsync(key);
        await this.Execute(Action);
    }
