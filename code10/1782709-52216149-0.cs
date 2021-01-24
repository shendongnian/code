    using Microsoft.TeamFoundation.Client;
    using System;
    using Microsoft.TeamFoundation.SourceControl.WebApi;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using System.Collections.Generic;
    
    namespace ConsoleX
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri url = new Uri("https://tfsuri");
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(url);
                VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
                IEnumerable<Changeset> cses = vcs.QueryHistory("Path here could be local path or server path", RecursionType.Full);
                foreach (Changeset cs in cses)
                {
                    Console.WriteLine(cs.ChangesetId);
                    Console.WriteLine(cs.Comment);
                }
                Console.ReadLine();
            }
        }
    }
