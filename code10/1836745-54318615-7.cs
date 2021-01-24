    namespace ProjectBusiness
    {
      public interface IProjectBO { .. }
      public interface IOrganization 
      { 
        Guid OrganizationId { get; }
      }
      private class ProjectBA : IProjectBO
      {
        private readonly IProjectDA _projectDA;
        private readonly IIdentity _identity;
        private readonly IOrganization _organization;
        public  ProjectLogic(IProjectDA projectDA, 
          IIdentity identity,
          IOrganizationContext organizationContext)
        {
          _projectDA = projectDA;
          _identity = identity;
        }
        public IProjectBO GetProject(Guid id)
        {
          var do = _projectDA
            .GetProject(id, _organization);
          var result = map.To<ProjectBO>(do);
          return result;
        }
      }
      public interface IProjectBO { .. }
      private class ProjectBO 
      { 
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CategoryId { get; set; }
      }
    }
