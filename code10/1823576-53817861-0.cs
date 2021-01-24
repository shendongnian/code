    public class AppContext : DbContext
    {
        public AppContext(): base("name=DefaultConnection")
        {
            Database.SetInitializer<AppContext>(new DBContextInitializer<AppContext>()); //Used for seeding. 
        }
        public virtual DbSet<Attendee> Attendees { get; set; }  
    }
 
    public class DBContextInitializer<T> : DropCreateDatabaseAlways<AppContext>
        {
            protected override void Seed(AppContext context)
            {
                var attendee = new Attendee { Id = 0, FirstName = "XXX" };
                context.Attendees.Add(attendee);
                base.Seed(context);
            }
        }
