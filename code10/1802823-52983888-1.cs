        public class LEMClaimRequirement : IAuthorizationRequirement
        {
        public LEMClaimRequirement(ELocation[] eLocations, EEntity[] eEntities = null)
        {
            Locations = eLocations;
            Entitys = eEntities;
        }
        public ELocation[] Locations
        {
            get; set;
        }
        public EEntity[] Entitys
        {
            get; set;
        }
        }
