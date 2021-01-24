    [HttpGet]
    public async Task<List<ScheduleDTO>> getAllScheds(){
        return await _context.Schedules.Select(s=>new ScheduleDTO() {
            scheduleId: s.Id,
            teamId1: s.Team1Id,
            teamId2: s.Team2Id,
            scheduleDate: "2016-04-30T19:00:00",
            week: "1",
            stadiumId: 3,
            createdBy: null,
            createdDate: "2016-07-07T13:09:32.797",
            Team1:s.Team1,
            Team2:_context.Teams.FirstOrDefault(x=>x.Id==s.Team1Id) //not recommended
        });
    }  
