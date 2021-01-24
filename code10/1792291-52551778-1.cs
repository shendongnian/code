    public class Section
    {
        public int? SectionID {get;set;}
    }
    ....
    public async Task<SectionDTO<Section>> GetSection(int scheduleId)
    {
        var query = _context.MlfbScheduleSectionRows
                            .Where(s => s.ScheduleId == scheduleId)        
                            .Select(s => s.SectionId)
                            .Distinct();
        var data = await query.ToListAsync();
        var sections=data.Select(id=>new Section{SectionID=id})
                         .ToList();
        return new SectionDTO<Section>("Success",scheduleId,sections);
     }
