    public async Task<List<RecordsByDateDTO>> GetUniqueRecordsByDate(int bId)
    {
         var recordsByDate = await _context.Records.Where(r => r.SId == bId).GroupBy(r => r.Date)
                                  .Select(group => new RecordsByDateDTO
                                  {
                                       Date =  group.Key,
                                       Records = group.ToList()
                                  }).OrderBy(r => r. Date).ToListAsync();
        return recordsByDate;
    } 
