    public class BuildingsManager : DomainService, IBuildingsManager
    {
        public Buildings getBuildingsById(int id)
        {
            return _repositoryBuildings.GetAll().AsNoTracking().First(id);
        }
        // ...
    }
