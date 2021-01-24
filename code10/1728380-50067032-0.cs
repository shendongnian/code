    using Microsoft.Build.Evaluation;
    
    using System.Collections.Generic;
    
    namespace NuGetReference
    {
        public static class Reference
        {
            public static void CreateReference(string projectName, string packageName, string packageVersion)
            {
                Project project = ProjectCollection.GlobalProjectCollection.LoadProject(projectName);
    
                project.AddItemFast("PackageReference", packageName, new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("Version", packageVersion) });
    
                project.Save();
            }
        }
    }
