    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using Microsoft.VisualStudio.Services.Client;
    using System;
    
    namespace RetrieveTestSteps
    {
        class Program
        {
            static void Main(string[] args)
            {
                var u = new Uri("http://server:8080/tfs/DefaultCollection");
                var c = new VssClientCredentials();
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(u, c);
                tpc.EnsureAuthenticated();   
                ITestManagementService itms = tpc.GetService<ITestManagementService>();
                ITestManagementTeamProject ittp = itms.GetTeamProject("LCScrum");
                ITestSuiteBase suite = ittp.TestSuites.Find(352);
                ITestCaseCollection testCaseCollection = suite.AllTestCases;
    
                foreach (var tc in testCaseCollection)
                {
                    ITestCase testcase = ittp.TestCases.Find(tc.Id);
    
                    foreach (ITestAction action in testcase.Actions)
                    {
                        Console.WriteLine(String.Format("{0} - {1}", testcase.Id, action));
                    }
                }
                Console.Read();
            }
        }
    }
