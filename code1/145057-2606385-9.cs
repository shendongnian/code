    using System.CodeDom.Compiler;
    using System.Linq;
	class NamespaceTester : IDisposable
	{
		private CodeDomProvider provider = CodeDomProvider.CreateProvider("c#");
		private CompilerParameters settings = new CompilerParameters();
		private CompilerResults results;
		public bool Test(string[] namespaces)
		{
			results = provider.CompileAssemblyFromSource(
				settings,
				namespaces.Select(n => String.Format("using {0};", n)).ToArray());
			return results.Errors
				.OfType<CompilerError>()
				.Any(e => String.Equals(
					e.ErrorText,
					"CS0234",
					StringComparison.Ordinal));
		}
		public void Dispose()
		{
			if (results != null)
			{
				System.IO.File.Delete(results.CompiledAssembly.Location);
			}
		}
	}
