    static void Main(string[] args)
    {
        var results = GetTfsProjects(new Uri("http://mytfsserver:8080/tfs/DefaultCollection"));
    }
    
    private static List<string> GetTfsProjects(Uri tpcAddress)
    {
        var tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(tpcAddress);
        tpc.Authenticate();
        var workItemStore = new WorkItemStore(tpc);
        var projectList = (from Project pr in workItemStore.Projects select pr.Name).ToList();
    
        return projectList;
    }
