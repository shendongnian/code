    class SchoolRepository : IDisposable, ISchoolQuerier
    {
        private SchoolRepository() : this (ISchoolQuerier)(new SchoolDbContext())
        {   // default constructor used default SchoolDbContext
        }
        private SchoolRepository(ISchoolQuerier querier)
        {   // use the provided querier
            // this constructor is useful for unit tests
            this.querier = querier;
        }
        private bool isDisposed = false;
        private readonly ISchoolQuerier;
        #region IDisposable
        public void Dispose()
        {
             this.Dispose(true);
             GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
             if (disposing && !this.isDisposed)
             {
                 IDisposable disposableSchool = this.SchoolQuerier as IDisposable;
                 if (disposableSchool != null)
                 {
                     this.schoolDbContext.Dispose();
                 }
                 this.isDisposed = true;
             }
        }
        #endregion IDispose
        #region ISchoolQuerier
        public IQueryable<Teacher> Teachers {get{return this.SchoolDbContext.Teachers;}}
        public IQueryable<Student> Students {get{return this.SchoolDbContext.Students;}}
