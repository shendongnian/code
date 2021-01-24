    public async Task<Entry> UpdateEntryAsync(Entry updateEntry)
    {
        DALENTRY entry = await _ctx.Set<DALENTRY >().SingleOrDefaultAsync(a => a.ID == updateEntry.IdEntry);
        entry.FIELD= updateEntry.IdField,
        _ctx.Update(entry);
        await _ctx.SaveChangesAsync();
        return updateEntry;
    }
