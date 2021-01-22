    using ICSharpCode.Decompiler;
    using ICSharpCode.Decompiler.CSharp;
    using ICSharpCode.Decompiler.TypeSystem;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    public static class CSharpRunner
    {
       public static object Run(string snippet, IEnumerable<Assembly> references, string typeName, string methodName, params object[] args) =>
          Invoke(Compile(Parse(snippet), references), typeName, methodName, args);
 
       public static object Run(MethodInfo methodInfo, params object[] args)
       {
          var refs = methodInfo.DeclaringType.Assembly.GetReferencedAssemblies().Select(n => Assembly.Load(n));
          return Invoke(Compile(Decompile(methodInfo), refs), methodInfo.DeclaringType.FullName, methodInfo.Name, args);
       }
 
       private static Assembly Compile(SyntaxTree syntaxTree, IEnumerable<Assembly> references = null)
       {
          if (references is null) references = new[] { typeof(object).Assembly, typeof(Enumerable).Assembly };
          var mrefs = references.Select(a => MetadataReference.CreateFromFile(a.Location));
          var compilation = CSharpCompilation.Create(Path.GetRandomFileName(), new[] { syntaxTree }, mrefs, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
 
          using (var ms = new MemoryStream())
          {
             var result = compilation.Emit(ms);
             if (result.Success)
             {
                ms.Seek(0, SeekOrigin.Begin);
                return Assembly.Load(ms.ToArray());
             }
             else
             {
                throw new InvalidOperationException(string.Join("\n", result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error).Select(d => $"{d.Id}: {d.GetMessage()}")));
             }
          }
       }
 
       private static SyntaxTree Decompile(MethodInfo methodInfo)
       {
          var decompiler = new CSharpDecompiler(methodInfo.DeclaringType.Assembly.Location, new DecompilerSettings());
          var typeInfo = decompiler.TypeSystem.MainModule.Compilation.FindType(methodInfo.DeclaringType).GetDefinition();
          return Parse(decompiler.DecompileTypeAsString(typeInfo.FullTypeName));
       }
 
       private static object Invoke(Assembly assembly, string typeName, string methodName, object[] args)
       {
          var type = assembly.GetType(typeName);
          var obj = Activator.CreateInstance(type);
          return type.InvokeMember(methodName, BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, args);
       }
 
       private static SyntaxTree Parse(string snippet) => CSharpSyntaxTree.ParseText(snippet);
    }
