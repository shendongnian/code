    internal static class Compiler
    {
        internal static void AssemblyFromFile(
            String classFilePath,
            String assemblyFilePath,
            String[] referencedAssemblies
        )
        {
            var cp = new CompilerParameters { OutputAssembly = assemblyFilePath };
    
            foreach (String ra in referencedAssemblies)
            {
                cp.ReferencedAssemblies.Add(ra);
            }
    
            CompilerResults cr = CodeDomProvider.CreateProvider("CSharp")
            /* continued --> */ .CompileAssemblyFromFile(cp, classFilePath);
    
            if (cr.Errors.Count > 0) // throw new X();
        }
    }
