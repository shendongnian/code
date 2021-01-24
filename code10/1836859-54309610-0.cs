    class Trip
    {
        public int Id {get; set;}
        ...
        // Every Trip has zero or more StopTimes (one-to-many):
        public virtual ICollection<StopTime> StopTimes {get; set;}
        // Every Trip has zero or more Routes (one-to-many):
        public virtual ICollection<Route> Routes {get; set;}
        // Every Trip has zero or more Calendars (one-to-many):
        public virtual ICollection<Calendar> Calendars {get; set;}
    }
    class StopTime
    {
        public int Id {get; set;}
        ...
        // Every StopTime belongs to exactly one Trip using foreign key:
        public int TripId {get; set;}
        public virtual Trip Trip {get; set;}
        // Every StopTime has zero or more Stops (one-to-many):
        public virtual ICollection<Stop> Stops {get; set;}
    }
    class Route
    {
        public int Id {get; set;}
        ...
        // every Route belongs to exactly one Trip (using foreign key)
        public int TripId {get; set;}
        public virtual Trip Trip {get; set;}
    }
