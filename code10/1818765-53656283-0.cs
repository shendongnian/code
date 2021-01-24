    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    namespace MyNamespaceHere.Services.Common.Utilities
    {
        public static class LaunchSettingsLoader
        {
            public static void LaunchSettingsFixture(string launchSettingsPath = "Properties\\launchSettings.json", string profileName = "UnitTesting")
            {
                using (var file = File.OpenText(launchSettingsPath))
                {
                    var reader = new JsonTextReader(file);
                    var jObject = JObject.Load(reader);
    
                    var allprofiles = jObject
                        .GetValue("profiles", StringComparison.OrdinalIgnoreCase);
    
                    // ideally we use this
                    var variables = jObject
                        .GetValue("profiles", StringComparison.OrdinalIgnoreCase)
                        //select a proper profile here
                        .SelectMany(profiles => profiles.Children())
                        //.Where(p => p.Value<String> == profileName)
                        .SelectMany(profile => profile.Children<JProperty>())
                        .Where(prop => prop.Name == "environmentVariables")
                        .SelectMany(prop => prop.Value.Children<JProperty>())
                        .ToList();
    
                    Console.WriteLine(variables?.Count);
                    
                    var profilesDictJToken = allprofiles.ToObject<Dictionary<string, JToken>>();
                    var unitTestingProfile = profilesDictJToken[profileName];
                    var unitTestingProfileDictJToken = unitTestingProfile.ToObject<Dictionary<string, JToken>>();
                    var environmentVariables = unitTestingProfileDictJToken["environmentVariables"];
                    var environmentVariablesList = environmentVariables.ToList();
    
                    foreach (var variable in environmentVariablesList)
                    {
                        var name = ((JProperty)variable).Name;
                        var value = ((JProperty)variable).Value.ToString();
                        Environment.SetEnvironmentVariable(name, value);
                    }
                }
            }
        }
    }
