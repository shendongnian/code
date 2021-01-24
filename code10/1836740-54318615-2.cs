    namespace StatisticsBusiness
    {
      public interface IStatisticsBO 
      {
        IEnumerable<ICategoryStatisticBO> CategoryStatistics { get; set; }
      }
      public interface ICategoryStaticBO
      {
        Guid CategoryId { get; }
        int ProjectCount { get; }
      }
      private class StatisticsBA : IStatisticsBO
      {
        private readonly IProjectDA _projectDA;
        private readonly IIdentity _identity;
        public  ProjectLogic(IProjectDA projectDA, 
          IIdentity identity)
        {
          _projectDA = projectDA;
          _identity = identity;
        }
        public IProjectBO GetOrderedCategoryPopularity()
        {
          var do = _projectDA
            .GetProjectCategoryCounts()
          var result = map.To<IStatisticsBO>(do);
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
