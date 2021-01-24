    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string teamProjectName = "TFSCMMI";
                int parentTestSuiteId = 819; // or test plan id
                var TFSCurrentProjectCollection = new TfsTeamProjectCollection(new Uri("http://tfs-srv:8080/tfs/defaultcollection"));
                var testStore = TFSCurrentProjectCollection.GetService<ITestManagementService>();
                var teamProject = testStore.GetTeamProject(teamProjectName);
                var testSuite = teamProject.TestSuites.Find(parentTestSuiteId);
                if (testSuite.TestSuiteType == TestSuiteType.StaticTestSuite)
                {
                    var staticSuite = testSuite as IStaticTestSuite;
                    foreach (var childSuite in staticSuite.Entries)
                    {
                        Console.WriteLine("Test suite id " + childSuite.Id + " name '" + childSuite.Title + "'");
                    }
                }
            }
        }
    }
