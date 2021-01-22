            string code = "using FileHelpers;\r\n\r\n";
            code += "[DelimitedRecord(\"" + delimiter + "\")]\r\n";
            code += "public class CustomCSVInputFile ";
            code += "{ \r\n";
            foreach (string column in columnList)
            {
              code += "   public string " + column.Replace(" ", "") + ";\r\n";
            }
            code += "}\r\n";
            CompilerResults compilerResults = CompileScript(code);
...
        public static CompilerResults CompileScript(string source)
        {
            CompilerParameters parms = new CompilerParameters();
            FileHelperEngine engine;
            parms.GenerateExecutable = false;
            parms.GenerateInMemory = true;
            parms.IncludeDebugInformation = false;
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "").Trim();
            parms.ReferencedAssemblies.Add(Path.Combine(path, "FileHelpers.dll"));
            CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp");
            
            return compiler.CompileAssemblyFromSource(parms, source);
        } 
