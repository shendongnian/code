    using Microsoft.TeamFoundation.VersionControl.Client;
    using Microsoft.TeamFoundation.Client;
    class Program
    {
        static void Main(string[] args)
        {
            string collection = @"http://ictfs2015:8080/tfs/DefaultCollection";
            TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(TfsTeamProjectCollection.GetFullyQualifiedUriForName(collection));
            tfs.EnsureAuthenticated();
            VersionControlServer vcs = tfs.GetService<VersionControlServer>();
            TeamProject[] teamProjects = vcs.GetAllTeamProjects(true);
    
            foreach (TeamProject proj in teamProjects)
            {
                System.Console.WriteLine(string.Format("Team Project: {0}", proj.Name));
            }
            System.Console.ReadLine();
        }
    }
