    class Repository
    {
        public Respository(MyDbContext db)
        {
            this.db = db;
        }
        private readonly MyDbContext db;
        private IReadonlyCollection<ProfileCourse> profilesCourses = null;
        public IEnumerable<Profile> Profiles => this.db.Profiles;
        public IEnumerable<Course> Courses => this.db.Courses;
        public IEnumerable<ProfileCourse> ProfilesCourses
        {
             get
             {
                 if (this.profilesCourses == null
                 {
                     this.profilesCourses = ... // the SelectMany from above
                         .ToList();
                 }
                 return this.profilesCourses;
             }
        }
    }
