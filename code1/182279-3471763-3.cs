    using System;
    using ThoughtWorks.CruiseControl.Core;
    using ThoughtWorks.CruiseControl.Remote;
    using ThoughtWorks.CruiseControl.Remote.Messages;
    
    namespace CruiseControlInterface
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ipAddressOrHostNameOfCCServer = ""; // Complete this value
                var client = new CruiseServerHttpClient(
                    string.Format("http://{0}/ccnet/",ipAddressOrHostNameOfCCServer));
    
                foreach (var projectStatus in client.GetProjectStatus())
                {
                    Console.WriteLine("{0} - {1}", projectStatus.Name, projectStatus.BuildStatus);
                }
            }
        }
    }
