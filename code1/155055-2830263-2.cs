            CodeDomProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();            
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, @"
                namespace Dynamic
                {
                    public class A
                    {
                    }
                }
                ");
            Assembly assem = results.CompiledAssembly;
            CodeDomProvider provider2 = new CSharpCodeProvider();
            CompilerParameters parameters2 = new CompilerParameters();
            parameters2.ReferencedAssemblies.Add(assem.Location);
            parameters2.GenerateInMemory = true;
            CompilerResults results2 = provider2.CompileAssemblyFromSource(parameters2, @"
                namespace Dynamic
                {
                    public class B : A
                    {
                    }
                }
                ");
            if (results2.Errors.HasErrors)
            {
                foreach (CompilerError error in results2.Errors)
                {
                    Console.WriteLine(error.ErrorText);
                }
            }
            else
            {
                Assembly assem2 = results2.CompiledAssembly;
            }
