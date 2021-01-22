    public class Program
    {
        static void Main(string[] args)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            string path = Directory.GetCurrentDirectory();
            foreach (string dll in Directory.GetFiles(path, "*.dll"))
            {
                assemblies.Add(Assembly.LoadFile(dll));
            }
            assemblies = assemblies.Distinct().ToList();
            new ResourceGenerator(assemblies);
        }
    }
