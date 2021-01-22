    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    
    using Microsoft.CSharp;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
    	public interface IDynamicTypeNameMapper
    	{
    		string GetTypeName();
    	}
    
    	class Program
    	{
    		static readonly string[] csharpKeywords = new[]
    		{
                "byte",
                "short",
    			"int",
                "long",
                "float",
                "double",
                "string"
    		};
    
    		static Dictionary<string, IDynamicTypeNameMapper> s_mappers;
    
    		static void Main(string[] args)
    		{
    			s_mappers = new Dictionary<string, IDynamicTypeNameMapper>();
    
    			var provider = new CSharpCodeProvider();
    			var options = new CompilerParameters();
    			options.ReferencedAssemblies.Add("ConsoleApplication1.exe");
    			options.GenerateInMemory = true;
    
    			var stopwatch = new Stopwatch();
    			stopwatch.Start();
    			foreach (string keyword in csharpKeywords)
    			{
    				string className = "DynamicTypeNameMapper_" + keyword;
    				string literal = "using System; using ConsoleApplication1; namespace Test { public class " + className + ": IDynamicTypeNameMapper { public string GetTypeName() { return typeof(" + keyword + ").FullName; } } }";
    				var snippet = new CodeSnippetCompileUnit(literal);
    
    				var results = provider.CompileAssemblyFromDom(options, snippet);
    
    				var typeNameMapper = results.CompiledAssembly.CreateInstance("Test." + className) as IDynamicTypeNameMapper;
    				if (typeNameMapper != null)
    				{
    					s_mappers.Add(keyword, typeNameMapper);
    					Console.WriteLine(typeNameMapper.GetTypeName());
    				}
    			}
    			stopwatch.Stop();
    			Console.WriteLine("Inital time: " + stopwatch.Elapsed.ToString());
    
    			stopwatch.Reset();
    			stopwatch.Start();
    
    			for (int i = 0; i < 1000; i++)
    			{
    				foreach (string keyword in csharpKeywords)
    				{
    					s_mappers[keyword].GetTypeName();
    				}
    			}
    			stopwatch.Stop();
    
    			Console.WriteLine("Cached time: " + stopwatch.Elapsed.ToString());
    
    			Console.ReadLine();
    		}
    	}
    }
