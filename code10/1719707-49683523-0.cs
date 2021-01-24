    public class BuildingService
    {
        private readonly IDataService _dataService;
        public BuildingService(IDataService dataService)
        {
             _dataService = dataService;
        }
        public IEnumerable<Building> GetBuildings(int propertyId)
        {
            if (propertyId < 0)
            {
                throw new ArgumentException("Negative id not allowed");
            }
            if (propertyId == 0)
            {
                return Enumerable.Empty<Building>();
            }
            return _myDataService.GetBuildingsOfProperty(int propertyId);
        }
    }
