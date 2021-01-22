    public static class AppDomainExtensions
    {
        public static Assembly GetAssemblyByName(this AppDomain domain, string assemblyName)
        {
            return domain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == assemblyName);
        }
    }
