    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    
    namespace WebServicesConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ListsWebService.Lists listsWebSvc = new WebServicesConsoleApp.ListsWebService.Lists();
                    listsWebSvc.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    listsWebSvc.Url = "http://servername/sites/SiteCollection/SubSite/_vti_bin/Lists.asmx";
                    XmlNode node = listsWebSvc.GetList("Issues");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
