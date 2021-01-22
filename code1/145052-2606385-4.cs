    using System.CodeDom.Compiler;
    using System.Linq;
	class NamespaceTester
	{
		private CodeDomProvider provider = CodeDomProvider.CreateProvider("c#");
		private CompilerParameters settings = new CompilerParameters() { GenerateInMemory = true };
		public bool Test(string[] namespaces)
		{
			var result = provider.CompileAssemblyFromSource(
				settings,
				namespaces.Select(n => String.Format("using {0};", n)).ToArray());
			// you can search for specific error
			// or check any error existence using result.Errors.HasErrors
			return result.Errors
				.OfType<CompilerError>()
				.Count(e => e.ErrorText == "CS0234") > 0;
		}
	}
