    namespace CompileScriptExample
    { 
    public class ScriptRunner
    {
        public static string RunScript(string scriptCode, string scriptParameter)
        {
   
            CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
            //configure parameters
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.IncludeDebugInformation = false;
            string reference;
            // Set reference to current assembly - this reference is a hack for the example..
            reference = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            parameters.ReferencedAssemblies.Add(reference+"\\CompileScriptExample.exe");
            //compile
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, new string[] { scriptCode });
            if (results.Errors.Count == 0)
            {
                IStringManipulator compiledScript=(IStringManipulator)FindInterface(results.CompiledAssembly, "IStringManipulator");
                return compiledScript.processString(scriptParameter);//run the script, pass the string param..
            }
            else
            {
                foreach(CompilerError anError in results.Errors)
                {
                    MessageBox.Show(anError.ErrorText);
                }
                //handle compilation errors here
                //..use results.errors collection
                throw new Exception("Compilation error...");
            }
        }
        private static object FindInterface(Assembly anAssembly, string interfaceName)
        {
            // find our interface type..
            foreach (Type aType in anAssembly.GetTypes())
            {
                if (aType.GetInterface(interfaceName, true) != null)
                    return anAssembly.CreateInstance(aType.FullName);
            }
            return null;
        }
    }
