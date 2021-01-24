    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace DisplayAllBranches
    {
        class Program
        {
            static void Main(string[] args)
            {
                string serverName = @"http://ictfs2015:8080/tfs/DefaultCollection";
    
                //1.Construct the server object
                TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri(serverName));
                VersionControlServer vcs = tfs.GetService<VersionControlServer>();
    
                //2.Query all root branches
                BranchObject[] bos = vcs.QueryRootBranchObjects(RecursionType.OneLevel);
    
                //3.Display all the root branches
                Array.ForEach(bos, (bo) => DisplayAllBranches(bo, vcs));
                Console.ReadKey();
            }
    
            private static void DisplayAllBranches(BranchObject bo, VersionControlServer vcs)
            {
                //0.Prepare display indentation
                for (int tabcounter = 0; tabcounter < recursionlevel; tabcounter++)
                    Console.Write("\t");
    
                //1.Display the current branch
                Console.WriteLine(string.Format("{0}", bo.Properties.RootItem.Item));
    
                //2.Query all child branches (one level deep)
                BranchObject[] childBos = vcs.QueryBranchObjects(bo.Properties.RootItem, RecursionType.OneLevel);
    
                //3.Display all children recursively
                recursionlevel++;
                foreach (BranchObject child in childBos)
                {
                    if (child.Properties.RootItem.Item == bo.Properties.RootItem.Item)
                        continue;
    
                    DisplayAllBranches(child, vcs);
                }
                recursionlevel--;
            }
    
            private static int recursionlevel = 0;
        }
    }
