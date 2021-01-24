    namespace ProjectsData
    {
      public interface IProjectDA 
      { 
        IProjectDO GetProject(Guid projectId, Guid organizationId);
      }
      private class ProjectDA : DbContext, IProjectDA
      {
        public ProjectDA (...)
        public IEnumerable<ProjectDO> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {... }
        public IProjectDO GetProject(Guid projectId, Guid organizationId)
        {
          var result = Projects
            .FirstOrDefault(p => p.Id == projectId && OrganizationId = organizationId);
          return result;
        }
      }
      public interface IProjectDO{ ... }
      private class ProjectDO: IProjectDO
      {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CategoryId { get; set; }
      }
    }
