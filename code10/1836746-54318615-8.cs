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
        public IEnumerable<IProjectBO GetOrderedCategoryPopularity()
        {
          var dos = _projectDA
            .GetProjectCategoryCounts()
          var result = map.To<IEnumerable<IStatisticsBO>>(dos);
          return result;
        }
      }
      public interface IStatisticsBO{ .. }
      private class StatisticsBO 
      { 
        public Guid CategoryId { get; }
        public int ProjectCount { get; }
      }
    }
