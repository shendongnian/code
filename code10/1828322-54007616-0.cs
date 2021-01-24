        public async Task<ApiListModel<EventPerYearReport>> GetEventPerYearReport(int id)
            {
                var results = _dbContext.Events
                    .Where(p => p.ProducerId == id)
                    .GroupBy(e => e.DateStartEvent.ToString("yyyy"), (year, values) 
        => new EventPerYear
                    {
                        year = year,
                        total = values.Count(),
                    }).ToList();
            return new ApiListModel<EventPerYearReport>()
            {
                Data = new EventPerYearRaport()
                {
                    eventsPerYear = results
                }
            };
        }
    
