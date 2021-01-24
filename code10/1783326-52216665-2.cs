    using System;
    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.VisualStudio.Services.Common;
    
    namespace RetrieveTaskList
    {
        class Program
        {
            static void Main(string[] args)
            {
                //For TFS :
                var tfsUrl = "http://ws-tfs2017:8080/tfs/DefaultCollection";
                var buildClient = new BuildHttpClient(new Uri(tfsUrl), new VssAadCredential());
    
                //For VSTS:
                //var tfsUrl = "https://{account}.visualstudio.com";
                //var buildClient = new BuildHttpClient(new Uri(tfsUrl), new VssBasicCredential(string.Empty, "PAT here"));
    
                var definitions = buildClient.GetFullDefinitionsAsync(project: "ScrumProject");
    
                foreach (var definition in definitions.Result)
                {
                    Console.WriteLine(string.Format("\n {0} - {1}:", definition.Id, definition.Name));
    
                    // Get BuildDefinitionStep to array, each of which has a task property that contains things like the name of the task and the inputs.
                    var tasks = definition.Steps.ToArray();
    
                    //Get each step/task from the array
                    foreach (var task in tasks)
                    {
                        Console.WriteLine(task.DisplayName);
                    }
                }
                Console.ReadLine();
            }
        }
    }
