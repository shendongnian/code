    public async Task<IActionResult> OnPostAsync(Guid? id)
    {
        try
        {
            if (await _context.TournamentBatch.AnyAsync(
                m => m.TournamentBatchID == id))
            {
                _context.TournamentBatch.Remove(TournamentBatch);
                _logger.LogInformation($"TournamentBatch.BeforeSaveChangesAsync ... ");
                await _context.SaveChangesAsync();
                _logger.LogInformation($"DbInitializer.AfterSaveChangesAsync ... ");
            }
            return RedirectToPage("./Index");
        }
        // ....
    }
