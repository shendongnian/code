    using System.CodeDom.Compiler;
    using System.Linq;
	class NamespaceTester
	{
		private CodeDomProvider provider = CodeDomProvider.CreateProvider("c#");
		private CompilerParameters settings = new CompilerParameters() { GenerateInMemory = true };
		public bool Test(string ns)
		{
			return provider.CompileAssemblyFromSource(
				settings,
				new[] { String.Format("using {0};", ns) })
					.Errors
					.OfType<CompilerError>()
					.Where(e => e.ErrorNumber == "CS0234")
						.ToArray()
						.Length > 0;
		}
