    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Compilation;
    
    public static class AssemblyLocator
    {
        private static readonly ReadOnlyCollection<Assembly> AllAssemblies;
        private static readonly ReadOnlyCollection<Assembly> BinAssemblies;
    
        static AssemblyLocator()
        {
            AllAssemblies = new ReadOnlyCollection<Assembly>(
                BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList());
    
            IList<Assembly> binAssemblies = new List<Assembly>();
    
            string binFolder = HttpRuntime.AppDomainAppPath + "bin\\";
            IList<string> dllFiles = Directory.GetFiles(binFolder, "*.dll",
                SearchOption.TopDirectoryOnly).ToList();
    
            foreach (string dllFile in dllFiles)
            {
                AssemblyName assemblyName = AssemblyName.GetAssemblyName(dllFile);
    
                Assembly locatedAssembly = AllAssemblies.FirstOrDefault(a =>
                    AssemblyName.ReferenceMatchesDefinition(
                        a.GetName(), assemblyName));
    
                if (locatedAssembly != null)
                {
                    binAssemblies.Add(locatedAssembly);
                }
            }
    
            BinAssemblies = new ReadOnlyCollection<Assembly>(binAssemblies);
        }
    
        public static ReadOnlyCollection<Assembly> GetAssemblies()
        {
            return AllAssemblies;
        }
    
        public static ReadOnlyCollection<Assembly> GetBinFolderAssemblies()
        {
            return BinAssemblies;
        }
    }
