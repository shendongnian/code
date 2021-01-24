        public class LEMClaimAuthorizeAttribute : AuthorizeAttribute
        {
        public LEMClaimAuthorizeAttribute(ELocation[] eLocations, EEntity[] eEntities = null)
        //public LEMClaimAuthorizeAttribute(ELocation[] eLocations)
        {
            Locations = eLocations;
            Entitys = eEntities;
        }
        const string POLICY_PREFIX_ELocation = "LEMClaim.ELocation";
        const string POLICY_PREFIX_EEntity = "LEMClaim.EEntity";
        public ELocation[] Locations
        {
            get
            {
                if (Enum.TryParse(typeof(ELocation[]), Policy.Substring(POLICY_PREFIX_ELocation.Length), out var locations))
                {
                    return (ELocation[])locations;
                }
                return default(ELocation[]);
            }
            set
            {
                if (value != null)
                {
                    int[] intVals = Array.ConvertAll(value, val => (int)val);
                    string arrayVal = string.Join(",", intVals);
                    Policy = Policy == null ? $"{POLICY_PREFIX_ELocation}{arrayVal}" : Policy + $";{POLICY_PREFIX_ELocation}{arrayVal}";
                }
            }
        }
        public EEntity[] Entitys
        {
            get
            {
                if (Enum.TryParse(typeof(EEntity[]), Policy.Substring(POLICY_PREFIX_EEntity.Length), out var locations))
                {
                    return (EEntity[])locations;
                }
                return default(EEntity[]);
            }
            set
            {
                if (value != null)
                {
                    int[] intVals = Array.ConvertAll(value, val => (int)val);
                    string arrayVal = string.Join(",", intVals);
                    Policy = Policy == null ? $"{POLICY_PREFIX_EEntity}{arrayVal}" : Policy + $";{POLICY_PREFIX_EEntity}{arrayVal}";
                }
            }
        }
        //remaining code omitted for brevity
         }
