    public class MyAssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies.Where(x=>!x.FullName.Contains("<nameOfAssemblyToExclude>")));            
            return assemblies;
        }
    }
