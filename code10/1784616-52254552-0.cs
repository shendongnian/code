    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.TestManagement.Client;
    using Microsoft.VisualStudio.Services.Client;
    using System;
    
    namespace RetrieveTestCaseDescription
    {
        class Program
        {
            static void Main(string[] args)
            {
                var u = new Uri("http://server:8080/tfs/DefaultCollection");
                var c = new VssClientCredentials();
                int TestCaseId = 57; 
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(u, c);
                tpc.EnsureAuthenticated();
    
                ITestManagementService test_service = (ITestManagementService)tpc.GetService(typeof(ITestManagementService));
                ITestManagementTeamProject project = test_service.GetTeamProject("ProjectNameHere");
                ITestCase testcase = project.TestCases.Find(TestCaseId);
                Console.WriteLine(String.Format("{0} - {1}", testcase.Id, testcase.Description));
                Console.Read();
            }
        }
    }
