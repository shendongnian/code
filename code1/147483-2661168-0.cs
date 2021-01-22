    namespace JTM
    {
        public class CSCompiler
        {
            protected string ot,
                rt,
                ss, es;
    
            protected bool rg, cg;
    
            public string Compile(String se, String fe, String[] rdas, String[] fs, Boolean rn)
            {
                System.CodeDom.Compiler.CodeDomProvider CODEPROV = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("CSharp");
                ot =
                    fe;
    
                System.CodeDom.Compiler.CompilerParameters PARAMS = new System.CodeDom.Compiler.CompilerParameters();
                // Ensure the compiler generates an EXE file, not a DLL.
                PARAMS.GenerateExecutable = true;
                PARAMS.OutputAssembly = ot;
                PARAMS.ReferencedAssemblies.Add(typeof(System.Xml.Linq.Extensions).Assembly.Location);
                foreach (String ay in rdas)
                {
                    if (ay.Contains(".dll"))
                        PARAMS.ReferencedAssemblies.Add(ay);
                    else
                    {
                        string refd = ay;
                        refd = refd + ".dll";
                        PARAMS.ReferencedAssemblies.Add(refd);
                    }
    
                }
    
                System.CodeDom.Compiler.CompilerResults rs = CODEPROV.CompileAssemblyFromFile(PARAMS, fs);
    
                if (rs.Errors.Count > 0)
                {
                    foreach (System.CodeDom.Compiler.CompilerError COMERR in rs.Errors)
                    {
                        es = es +
                            "Line number: " + COMERR.Line +
                            ", Error number: " + COMERR.ErrorNumber +
                            ", '" + COMERR.ErrorText + ";" +
                            Environment.NewLine + Environment.NewLine;
                    }
                }
                else
                {
                    // Compilation succeeded.
                    es = "Compilation Succeeded.";
    
                    if (rn) System.Diagnostics.Process.Start(ot);
                }
                return es;
            }
        }
    }
