    using Microsoft.Web.Administration;
    using System;
    using System.Collections.Generic;
    
    internal static class Sample
    {
        internal static void AddEnvironmentVariablesToWebSite(this ServerManager serverManager, KeyValuePair<string, string> environmentVariable, string siteName)
        {
            if (serverManager == null) throw new ArgumentNullException(nameof(serverManager));
    
            var config = serverManager.GetApplicationHostConfiguration();
            var aspNetCoreSection = config.GetSection("system.webServer/aspNetCore", siteName);
            var environmentVariablesCollection = aspNetCoreSection.GetCollection("environmentVariables");
    
            var addElement1 = environmentVariablesCollection.CreateElement(); // CreateElement() is equivalent to CreateElement("add")
            addElement1["name"] = environmentVariable.Key;
            addElement1["value"] = environmentVariable.Value;
            environmentVariablesCollection.Add(addElement1);
            serverManager.CommitChanges();
        }
    }
