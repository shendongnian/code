    class ChangeableSchoolRepository : IDisposable, ISchoolQuerier
    {
        public ChangeableSchoolRepository(SchooldDbContext dbContext)
        {
            this.schoolDbContext = dbContext;
        }
        private readonly SchoolDbContext;
        public IChangeableSet<Teacher> Teachers
        {
            get {return new DbSet(dbContext.Teachers);}
        }
        ... // etc for Students / Grades
        public void SaveChanges()
        {
            return this.SchoolDbcontext.SaveChanges();
        }
    }
