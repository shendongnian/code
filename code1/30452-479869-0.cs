    using System.CodeDom;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    // the compilation part
    
    // change the parameters as you see fit
    CompilerParameters cp = CreateCompilerParameters(); 
    var options = new System.Collections.Generic.Dictionary<string, string>();
    if (/* you want to use the 3.5 compiler*/)
    {
        options.Add("CompilerVersion", "v3.5");
    }
    var compiler = new CSharpCodeProvider(options);
    CompilerResults cr = compiler.CompileAssemblyFromFile(cp,filename);
    if (cr.Errors.HasErrors)
    {
        foreach (CompilerError err in cr.Errors)
        {
            // do something with the error/warning 
        }
    }
