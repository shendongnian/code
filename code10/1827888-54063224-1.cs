            var dlls = DependencyContext.Default.CompileLibraries
                .SelectMany(x => x.ResolveReferencePaths())
                .Distinct()
                .Where(x => x.Contains(Directory.GetCurrentDirectory()))
                .ToList();
            foreach (var item in dlls)
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
