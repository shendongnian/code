    namespace MySimpleService {
        // TODO: Modify the service behavior settings (instancing, concurrency etc) based on the service's requirements. Use ConcurrencyMode.Multiple if your service implementation
        //       is thread-safe.
        // TODO: NOTE: Please set IncludeExceptionDetailInFaults to false in production environments.
        [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class Service : AtomPubServiceBase, IAtomPubService {
            // TODO: These variables are used by the sample implementation. Remove if needed
            #region variables used in sample implementation
            const string xxx= "xxxx";
            List<SyndicationItem> booksmarkEntries = new List<SyndicationItem>();
            Dictionary<string, byte[]> collection1MediaItems = new Dictionary<string, byte[]>();
            Dictionary<string, string> collection1ContentTypes = new Dictionary<string, string>();
            #endregion
    
            public Service() {
                AddEntry("Main", "http:
