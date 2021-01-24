    class Volunteer
    {
        public int Id {get; set;}
        // every volunteer has zero or more Appointments (many-to-many)
        public virtual ICollection<Appointment> Appointments {get; set;}
        
        ...
    }
    class Appointment
    {
        public int Id {get; set}
        // every Appointment is attended by zero or more Volunteers (many-to-many)
        public virtual ICollection<Volunteer> Volunteers {get; set;}
        ...
    }
    public MyDbContext : DbContext
    {
        public DbSet<Volunteer> Volunteers {get; set;}
        public DbSet<Appointment> Appointments {get; set;}
    }
