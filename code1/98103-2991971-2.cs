static void Main(string[] args)
{
   ...
   AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
   ...
}
static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
{
   string assembliesDir = "your_directory";
   Assembly asm = Assembly.LoadFrom(Path.Combine(assembliesDir, args.Name + ".dll"));
   return asm;
}
