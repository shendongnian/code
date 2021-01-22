    repository.ReadAppointments().Where(a => repository.ReadAppointments().
         Any(b => 
             !(b.ID == a.ID) && 
             (a.SpaceConfigurationId == b.SpaceConfigurationId) &&
             !(a.EndetAt < b.StartedAt) &&
             !(a.StartedAt > b.EndetAt))).
         Select(t => t.ID).ToList();
