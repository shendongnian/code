			var refs = AppDomain.CurrentDomain.GetAssemblies();
			var refFiles = refs.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
			var cSharp = (new Microsoft.CSharp.CSharpCodeProvider()).CreateCompiler();
			var compileParams = new System.CodeDom.Compiler.CompilerParameters(refFiles);
			compileParams.GenerateInMemory = true;
			compileParams.GenerateExecutable = false;
			var compilerResult = cSharp.CompileAssemblyFromSource(compileParams, code);
			var asm = compilerResult.CompiledAssembly;
