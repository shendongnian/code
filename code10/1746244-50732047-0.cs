    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v3;
    using Google.Apis.Services;
    using static Google.Apis.Drive.v3.DriveService;
    
    namespace TestApiGoogle.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult GoogleAuth()
            {
                FileStream fsSource = new FileStream
                    (@"Path\secret_info.json", FileMode.Open, FileAccess.Read);
    
                string[] Scopes = { Scope.Drive };
                string ApplicationName = "Your app name";
    
                GoogleCredential credential = GoogleCredential.FromStream(fsSource)
                    .CreateScoped(Scopes);
    
                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
    
                // Define parameters of request.
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.PageSize = 10;
                listRequest.Fields = "nextPageToken, files(id, name)";
    
                // List files.
                IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                    .Files;
    
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        Console.WriteLine("{0} ({1})", file.Name, file.Id);
                    }
                }
                else
                {
                    Console.WriteLine("No files found.");
                }
    
                var jsonObject = new
                {
                    files
                };
    
                return Json(jsonObject, JsonRequestBehavior.AllowGet);
            }
        }
    }
