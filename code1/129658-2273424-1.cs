     public IQueryable<ClientInfo> GetConnectedClients()
     {
          return from cp in _context.Clients
                 where // ...
                 select new ClientInfo
                 {
                     Id = cp.Id,
                     ClientName = cp.ClientName,
                     LogEntry = new LogEntryInfo
                                {
                                    LogEntryId = cp.LogEntry.LogEntryId,
                                    GameFile = new GameFileInfo
                                               {
                                                   GameFileId = cp.LogEntry.GameFile.GameFileId,
                                                   // etc.
                                               },
                                    // etc.
                                },
                      // etc.
                 };
     }
