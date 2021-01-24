        try
        {
            //var tournamentBatchItems = await _context.TournamentBatchItem.Where(m => m.TournamentBatchID == id).ToListAsync();
            //_context.TournamentBatchItem.RemoveRange(tournamentBatchItems);
            //await _context.SaveChangesAsync();
            TournamentBatch = await _context.TournamentBatch.FindAsync(id);
            if (TournamentBatch != null)
            {
                // Department.rowVersion value is from when the entity
                // was fetched. If it doesn't match the DB, a
                // DbUpdateConcurrencyException exception is thrown.
                _context.TournamentBatch.Remove(TournamentBatch);
                _logger.LogInformation($"TournamentBatch.BeforeSaveChangesAsync ... ");
                await _context.SaveChangesAsync();
                _logger.LogInformation($"DbInitializer.AfterSaveChangesAsync ... ");
            }
            return RedirectToPage("./Index");
        }
        // ...
