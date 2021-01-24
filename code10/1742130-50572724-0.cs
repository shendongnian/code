    class Program
    {
        static void Main(string[] args)
        {
            var a = 1;
            var b = 2;
            Console.WriteLine(FN_ParseSnippet($"{a} + {b} * 2"));
            Console.ReadKey();
        }
        public static object FN_ParseSnippet(string snippet)
        {
            object ret = null;
            var usingList = new List<string>();
            usingList.Add("System");
            usingList.Add("System.Collections.Generic");
            usingList.Add("System.Text");
            usingList.Add("Microsoft.CSharp");
            //Create method
            CodeMemberMethod pMethod = new CodeMemberMethod();
            pMethod.Name = "Execute";
            pMethod.Attributes = MemberAttributes.Public;
            pMethod.ReturnType = new CodeTypeReference(typeof(object));
            pMethod.Statements.Add(new CodeSnippetExpression(" return " + snippet));
            //Create Class
            CodeTypeDeclaration pClass = new System.CodeDom.CodeTypeDeclaration("Compilator");
            pClass.Attributes = MemberAttributes.Public;
            pClass.Members.Add(pMethod);
            //Create Namespace
            CodeNamespace pNamespace = new CodeNamespace("MyNamespace");
            pNamespace.Types.Add(pClass);
            foreach (string sUsing in usingList)
                pNamespace.Imports.Add(new CodeNamespaceImport(sUsing));
            //Create compile unit
            CodeCompileUnit pUnit = new CodeCompileUnit();
            pUnit.Namespaces.Add(pNamespace);
            
            CompilerParameters param = new CompilerParameters();
            param.GenerateInMemory = true;
            List<AssemblyName> pReferencedAssemblys = new List<AssemblyName>();
            pReferencedAssemblys = Assembly.GetExecutingAssembly().GetReferencedAssemblies().ToList();
            pReferencedAssemblys.Add(Assembly.GetExecutingAssembly().GetName());
            pReferencedAssemblys.Add(Assembly.GetCallingAssembly().GetName());
            foreach (AssemblyName asmName in pReferencedAssemblys)
            {
                Assembly asm = Assembly.Load(asmName);
                param.ReferencedAssemblies.Add(asm.Location);
            }
            //Compile
            CompilerResults pResults = (new CSharpCodeProvider()).CreateCompiler().CompileAssemblyFromDom(param, pUnit);
            if (pResults.Errors != null && pResults.Errors.Count > 0)
            {
                //foreach (CompilerError pError in pResults.Errors)
                //    MessageBox.Show(pError.ToString());
            }
            var instance = pResults.CompiledAssembly.CreateInstance("MyNamespace.Compilator");
            ret = instance.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, instance, null);
            return ret;
        }
    }
