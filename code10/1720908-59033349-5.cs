    namespace YourNameSpace // important: use the same namespace your EDMX is using
    {
        public partial class FacilityEntities 
        {
            public FacilityEntities(string dbConnection) : base($"name={dbConnection}") { } 
        }
    }
