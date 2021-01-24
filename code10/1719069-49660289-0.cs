    // Requires Glob.cs, (c) 2013 Michael Ganss, downloaded via the NuGet package manager:
    // https://www.nuget.org/packages/Glob.cs
    // (In Visual Studio, go to Tools->NuGet Package Manager->Package Manager Console.)
    // PM> Install-Package Glob.cs -Version 1.3.0
    using Glob;
    namespace StackOverflow_cs
    {
       class Program
       {
          static void Main(string[] args)
          {
             List<string> directories = new List<string>();
             foreach (string arg in args)
             {
                var dirs = Glob.Glob.Expand(arg, true, true);
                foreach (var dir in dirs)
                {
                   directories.Add(dir.FullName);
                }
             }
             Console.WriteLine("Full list of directories specified by the command line args:");
             foreach (string dir in directories)
             {
                Console.WriteLine("    " + dir);
             }
             // Now go do what I want to do for each of these directories......
          }
       }
    }
