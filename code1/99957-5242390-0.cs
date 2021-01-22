    namespace Application.Service
    {
            [ServiceBehavior(UseSynchronizationContext = false,
            ConcurrencyMode = ConcurrencyMode.Multiple,
            InstanceContextMode = InstanceContextMode.PerCall),
            AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
            public class VendorService : IVendorService
            {
              public List<Vendor> RetrieveMultiple(int start, int limit, string sort, string dir)
              {
                 //I don't do any manual serialization
                 return new Vendor();
              }
            }
    }
