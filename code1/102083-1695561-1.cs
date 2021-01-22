        private IQueryable<Event> GetLatestSortedEvents()
        {
            // TODO: WARNING: HEAVY SQL QUERY! fix
            return this.GetSortedEvents().ToList()
                .Where(ModelExtensions.Event.IsUpcomingEvent())
                .AsQueryable();
        }
