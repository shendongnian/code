            var dlls = new List<string>();
            foreach (var compilationLibrary in deps.CompileLibraries)
            {
                foreach (var resolveReferencePath in compilationLibrary.ResolveReferencePaths())
                {
                    Console.WriteLine($"\t\tReference path: {resolveReferencePath}");
                    dlls.Add(resolveReferencePath);
                }
            }
            dlls = dlls.Distinct().ToList();
            var infolder = dlls.Where(x => x.Contains(Directory.GetCurrentDirectory())).ToList().Select(s=>s.Replace("\\","/"));
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Select(x=>x.CodeBase);
            infolder = infolder.Where(x => !assemblies.Any(q => q.Contains(x))).ToList();
            foreach (var item in infolder)
            {
                try
                {
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(item);
                }
                catch (System.IO.FileLoadException loadEx)
                {
                } // The Assembly has already been loaded.
                catch (BadImageFormatException imgEx)
                {
                } // If a BadImageFormatException exception is thrown, the file is not an assembly.
                catch (Exception ex)
                {
                }
            }
