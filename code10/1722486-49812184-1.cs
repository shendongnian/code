    using System;
    using Microsoft.SharePoint.Client;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string targetSiteURL = @"https://xxx.sharepoint.com/sites/xxx";
    
                var login = "xxx@xx.onmicrosoft.com";
                var password = "xxx";
               
                SharePointOnlineCredentials onlineCredentials = new SharePointOnlineCredentials(login, password);
    
                ClientContext ctx = new ClientContext(targetSiteURL);
    
                 
                ctx.Credentials = onlineCredentials;
    
                WebCreationInformation wci = new WebCreationInformation();
                wci.Url = "Site1"; // This url is relative to the url provided in the context
                wci.Title = "Site 1";
                wci.UseSamePermissionsAsParentSite = true;
                wci.WebTemplate = "STS#0";
                wci.Language = 1033;
    
                var newWeb = ctx.Web.Webs.Add(wci);
                ctx.Load(newWeb, w => w.Title);           
                ctx.ExecuteQueryAsync();
                Console.WriteLine("Web title:" + newWeb.Title);
                Console.ReadKey();
            }
        }
    }
