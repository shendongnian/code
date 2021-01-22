    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using Microsoft.CSharp;
    
    CSharpCodeProvider codeProvider = new CSharpCodeProvider();
    ICodeCompiler icc = codeProvider.CreateCompiler();
    System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateExecutable = false;
    parameters.OutputAssembly = "AutoGen.dll";
    CompilerResults results = icc.CompileAssemblyFromSource(parameters, yourCodeAsString);
