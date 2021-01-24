    public Task<Client> FindClientByIdAsync(string clientId)
    {
        var client = _context.Clients
            // ...
            .Include(x => x.Properties)
            .FirstOrDefault(x => x.ClientId == clientId);
        var model = client?.ToModel();
        return Task.FromResult(model);
    }
