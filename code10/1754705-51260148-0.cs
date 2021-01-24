        public IEnumerable<DatabaseList> GetAllClients()
        {
            _logger.LogInformation("Get all clients was called");
            var clients = _ctx.DatabaseList
                           .Include(d => d.DatabaseStatus)
                           .OrderBy(p => p.ClientName)
                           .ToList();
            return clients;
        }
