    public class BuildingService : IBuildingService {
        private readonly IDataContextFactory factory;
        
        public BuildingService(IDataContextFactory factory) {
            this.factory = factory
        }
        public IQueryable<Building> GetBuildings(int propertyId) {
            IQueryable<Building> buildings;
            using (var context = factory.CreateInstance()) {
                var Params = new List<SqlParameter> {
                    new SqlParameter("@PropertyId", propertyId)
                };
                
                buildings = context
                  .ExecuteQuery<Building>(System.Data.CommandType.StoredProcedure, "dbo.Building_List", Params.ToArray<object>())
                  .AsQueryable();
            }
            return buildings;
        }
    }
    
