            using Microsoft.TeamFoundation.Core.WebApi;
            using Microsoft.TeamFoundation.Core.WebApi.Types;
            using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
            using Microsoft.VisualStudio.Services.Common;
            using Microsoft.VisualStudio.Services.WebApi;
            using Microsoft.VisualStudio.Services.WebApi.Patch;
            using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            namespace ConsoleApp1
            {
                class Program
                {
                    static string ServiceURL = "https://your_name.visualstudio.com";
                    static string PAT = "your pat";
                    static void Main(string[] args)
                    {
                        string projectName = "your project";
                        string templateName = "Critical bug";
                        /*connect to service. I use VSTS. In your case: 
                        VssConnection connection = new VssConnection(new Uri(ServiceURL), new VssCredential());
                        https://docs.microsoft.com/ru-ru/azure/devops/integrate/get-started/client-libraries/samples?view=vsts
                        */
                        VssConnection connection = new VssConnection(new Uri(ServiceURL), new VssBasicCredential(string.Empty, PAT));
                        //get clients
                        var WitClient = connection.GetClient<WorkItemTrackingHttpClient>();
                        var ProjectClient = connection.GetClient<ProjectHttpClient>();
                        var project = ProjectClient.GetProject(projectName).Result;
                        //get context for default project team
                        TeamContext tmcntx = new TeamContext(project.Id, project.DefaultTeam.Id);
                        //get all template for team
                        var templates = WitClient.GetTemplatesAsync(tmcntx).Result;
                        //get tempate through its name
                        var id = (from tm in templates where tm.Name == templateName select tm.Id).FirstOrDefault();
                        if (id != null)
                        {
                            var template = WitClient.GetTemplateAsync(tmcntx, id).Result;
                            JsonPatchDocument patchDocument = new JsonPatchDocument();
                            foreach (var key in template.Fields.Keys) //set default fields from template
                                patchDocument.Add(new JsonPatchOperation()
                                {
                                    Operation = Operation.Add,
                                    Path = "/fields/" + key,
                                    Value = template.Fields[key]
                                });
                            //add any additional fields
                            patchDocument.Add(new JsonPatchOperation()
                            {
                                Operation = Operation.Add,
                                Path = "/fields/System.Title",
                                Value = "My critical bug"
                            });
                            var newWorkItem = WitClient.CreateWorkItemAsync(patchDocument, projectName, template.WorkItemTypeName).Result;
                        }            
                    }
                }
            }
