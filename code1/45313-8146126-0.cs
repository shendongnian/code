    // VSSolution
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.IO;
    using AbstractX.Contracts;
    namespace VSProvider
    {
        public class VSSolution : IVSSolution
        {
            //internal class SolutionParser 
            //Name: Microsoft.Build.Construction.SolutionParser 
            //Assembly: Microsoft.Build, Version=4.0.0.0 
            static readonly Type s_SolutionParser;
            static readonly PropertyInfo s_SolutionParser_solutionReader;
            static readonly MethodInfo s_SolutionParser_parseSolution;
            static readonly PropertyInfo s_SolutionParser_projects;
            private string solutionFileName;
            private List<VSProject> projects;
            public string Name
            {
                get
                {
                    return Path.GetFileNameWithoutExtension(solutionFileName);
                }
            }
            public IEnumerable<IVSProject> Projects
            {
                get
                {
                    return projects;
                }
            }
            static VSSolution()
            {
                s_SolutionParser = Type.GetType("Microsoft.Build.Construction.SolutionParser, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
                s_SolutionParser_solutionReader = s_SolutionParser.GetProperty("SolutionReader", BindingFlags.NonPublic | BindingFlags.Instance);
                s_SolutionParser_projects = s_SolutionParser.GetProperty("Projects", BindingFlags.NonPublic | BindingFlags.Instance);
                s_SolutionParser_parseSolution = s_SolutionParser.GetMethod("ParseSolution", BindingFlags.NonPublic | BindingFlags.Instance);
            }
            public string SolutionPath
            {
                get
                {
                    var file = new FileInfo(solutionFileName);
                    return file.DirectoryName;
                }
            }
            public VSSolution(string solutionFileName)
            {
                if (s_SolutionParser == null)
                {
                    throw new InvalidOperationException("Can not find type 'Microsoft.Build.Construction.SolutionParser' are you missing a assembly reference to 'Microsoft.Build.dll'?");
                }
                var solutionParser = s_SolutionParser.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First().Invoke(null);
                using (var streamReader = new StreamReader(solutionFileName))
                {
                    s_SolutionParser_solutionReader.SetValue(solutionParser, streamReader, null);
                    s_SolutionParser_parseSolution.Invoke(solutionParser, null);
                }
                this.solutionFileName = solutionFileName;
                projects = new List<VSProject>();
                var array = (Array)s_SolutionParser_projects.GetValue(solutionParser, null);
                for (int i = 0; i < array.Length; i++)
                {
                    projects.Add(new VSProject(this, array.GetValue(i)));
                }
            }
            public void Dispose()
            {
            }
        }
    }
    // VSProject
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using AbstractX.Contracts;
    using System.Collections;
    namespace VSProvider
    {
        [DebuggerDisplay("{ProjectName}, {RelativePath}, {ProjectGuid}")]
        public class VSProject : IVSProject
        {
            static readonly Type s_ProjectInSolution;
            static readonly Type s_RootElement;
            static readonly Type s_ProjectRootElement;
            static readonly Type s_ProjectRootElementCache;
            static readonly PropertyInfo s_ProjectInSolution_ProjectName;
            static readonly PropertyInfo s_ProjectInSolution_ProjectType;
            static readonly PropertyInfo s_ProjectInSolution_RelativePath;
            static readonly PropertyInfo s_ProjectInSolution_ProjectGuid;
            static readonly PropertyInfo s_ProjectRootElement_Items;
            private VSSolution solution;
            private string projectFileName;
            private object internalSolutionProject;
            private List<VSProjectItem> items;
            public string Name { get; private set; }
            public string ProjectType { get; private set; }
            public string RelativePath { get; private set; }
            public string ProjectGuid { get; private set; }
            public string FileName
            {
                get
                {
                    return projectFileName;
                }
            }
            static VSProject()
            {
                s_ProjectInSolution = Type.GetType("Microsoft.Build.Construction.ProjectInSolution, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
                s_ProjectInSolution_ProjectName = s_ProjectInSolution.GetProperty("ProjectName", BindingFlags.NonPublic | BindingFlags.Instance);
                s_ProjectInSolution_ProjectType = s_ProjectInSolution.GetProperty("ProjectType", BindingFlags.NonPublic | BindingFlags.Instance);
                s_ProjectInSolution_RelativePath = s_ProjectInSolution.GetProperty("RelativePath", BindingFlags.NonPublic | BindingFlags.Instance);
                s_ProjectInSolution_ProjectGuid = s_ProjectInSolution.GetProperty("ProjectGuid", BindingFlags.NonPublic | BindingFlags.Instance);
                s_ProjectRootElement = Type.GetType("Microsoft.Build.Construction.ProjectRootElement, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
                s_ProjectRootElementCache = Type.GetType("Microsoft.Build.Evaluation.ProjectRootElementCache, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
                s_ProjectRootElement_Items = s_ProjectRootElement.GetProperty("Items", BindingFlags.Public | BindingFlags.Instance);
            }
            public IEnumerable<IVSProjectItem> Items
            {
                get
                {
                    return items;
                }
            }
            public VSProject(VSSolution solution, object internalSolutionProject)
            {
                this.Name = s_ProjectInSolution_ProjectName.GetValue(internalSolutionProject, null) as string;
                this.ProjectType = s_ProjectInSolution_ProjectType.GetValue(internalSolutionProject, null).ToString();
                this.RelativePath = s_ProjectInSolution_RelativePath.GetValue(internalSolutionProject, null) as string;
                this.ProjectGuid = s_ProjectInSolution_ProjectGuid.GetValue(internalSolutionProject, null) as string;
                this.solution = solution;
                this.internalSolutionProject = internalSolutionProject;
                this.projectFileName = Path.Combine(solution.SolutionPath, this.RelativePath);
                items = new List<VSProjectItem>();
                if (this.ProjectType == "KnownToBeMSBuildFormat")
                {
                    this.Parse();
                }
            }
            private void Parse()
            {
                var stream = File.OpenRead(projectFileName);
                var reader = XmlReader.Create(stream);
                var cache = s_ProjectRootElementCache.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First().Invoke(new object[] { true });
                var rootElement = s_ProjectRootElement.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First().Invoke(new object[] { reader, cache });
                stream.Close();
                var collection = (ICollection)s_ProjectRootElement_Items.GetValue(rootElement, null);
                foreach (var item in collection)
                {
                    items.Add(new VSProjectItem(this, item));
                }
            }
            public IEnumerable<IVSProjectItem> EDMXModels
            {
                get 
                {
                    return this.items.Where(i => i.ItemType == "EntityDeploy");
                }
            }
            public void Dispose()
            {
            }
        }
    }
    // VSProjectItem
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using AbstractX.Contracts;
    namespace VSProvider
    {
        [DebuggerDisplay("{ProjectName}, {RelativePath}, {ProjectGuid}")]
        public class VSProjectItem : IVSProjectItem
        {
            static readonly Type s_ProjectItemElement;
            static readonly PropertyInfo s_ProjectItemElement_ItemType;
            static readonly PropertyInfo s_ProjectItemElement_Include;
            private VSProject project;
            private object internalProjectItem;
            private string fileName;
            static VSProjectItem()
            {
                s_ProjectItemElement = Type.GetType("Microsoft.Build.Construction.ProjectItemElement, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
                s_ProjectItemElement_ItemType = s_ProjectItemElement.GetProperty("ItemType", BindingFlags.Public | BindingFlags.Instance);
                s_ProjectItemElement_Include = s_ProjectItemElement.GetProperty("Include", BindingFlags.Public | BindingFlags.Instance);
            }
            public string ItemType { get; private set; }
            public string Include { get; private set; }
            public VSProjectItem(VSProject project, object internalProjectItem)
            {
                this.ItemType = s_ProjectItemElement_ItemType.GetValue(internalProjectItem, null) as string;
                this.Include = s_ProjectItemElement_Include.GetValue(internalProjectItem, null) as string;
                this.project = project;
                this.internalProjectItem = internalProjectItem;
                // todo - expand this
                if (this.ItemType == "Compile" || this.ItemType == "EntityDeploy")
                {
                    var file = new FileInfo(project.FileName);
                    fileName = Path.Combine(file.DirectoryName, this.Include);
                }
            }
            public byte[] FileContents
            {
                get 
                {
                    return File.ReadAllBytes(fileName);
                }
            }
            public string Name
            {
                get 
                {
                    if (fileName != null)
                    {
                        var file = new FileInfo(fileName);
                        return file.Name;
                    }
                    else
                    {
                        return this.Include;
                    }
                }
            }
        }
    }
