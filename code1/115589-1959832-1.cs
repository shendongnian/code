    //I made up an IModule in namespace IMod, with string property S
    string dynamicCS = @"using System; namespace DYN 
                 { public class Mod : IMod.IModule { public string S 
                     { get { return \"Im a module\"; } } } }";
    var compiler = new Microsoft.CSharp.CSharpCodeProvider().CreateCompiler();
    var options = new System.CodeDom.Compiler.CompilerParameters(
           new string[]{"System.dll", "IMod.dll"});
    var dynamicAssembly= compiler.CompileAssemblyFromSource(options, dynamicCS);
    //you need to check it for errors here
    var dynamicModuleTypes = dynamicAssembly.CompiledAssembly.GetExportedTypes()
        .Where(t => t.GetInterfaces().Contains(typeof(IMod.IModule)));
    var dynamicModules = dynModType.Select(t => (IMod.IModule)Activator.CreateInstance(t));
    
 
