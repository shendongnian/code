    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="$(SolutionDir)\packages\System.ValueTuple.4.3.0\lib\netstandard1.0\System.ValueTuple.dll" #>
    <#@ assembly name="$(SolutionDir)\packages\System.Collections.Immutable.1.3.1\lib\netstandard1.0\System.Collections.Immutable.dll" #>
    <#@ assembly name="$(SolutionDir)\packages\Microsoft.CodeAnalysis.Common.2.8.2\lib\netstandard1.3\Microsoft.CodeAnalysis.dll" #>
    <#@ assembly name="$(SolutionDir)\packages\Microsoft.CodeAnalysis.CSharp.2.8.2\lib\netstandard1.3\Microsoft.CodeAnalysis.CSharp.dll" #>
    <#@ assembly name="System.Runtime" #>
    <#@ assembly name="System.Text.Encoding" #>
    <#@ assembly name="System.Threading.Tasks" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="Microsoft.CodeAnalysis" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="Microsoft.CodeAnalysis.CSharp" #>
    <#@ import namespace="Microsoft.CodeAnalysis.CSharp.Syntax" #>
    <# 
        var solutionPath = Host.ResolveAssemblyReference("$(ProjectDir)");
        var files = Directory.GetFiles(solutionPath,"*.cs",SearchOption.AllDirectories);
        IEnumerable<ClassDeclarationSyntax> syntaxTrees = files.Select(x => CSharpSyntaxTree.ParseText(File.ReadAllText(x))).Cast<CSharpSyntaxTree>().SelectMany(c => c.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>());
        foreach(ClassDeclarationSyntax declaration in syntaxTrees.Where(x => (x.AttributeLists != null && x.AttributeLists.Count > 0 && x.AttributeLists.SelectMany(y => y.Attributes.Where(z=> z.Name.ToString()=="Views")).Any()))) {
            SyntaxNode namespaceNode = declaration.Parent;
            Write("\n\n");
            while(namespaceNode != null && !(namespaceNode is NamespaceDeclarationSyntax)) {
		        namespaceNode = namespaceNode.Parent;
	        }
	        if(namespaceNode != null) {
		        WriteLine("namespace " + ((NamespaceDeclarationSyntax)namespaceNode).Name.ToString() + " {");
	        }
            string modelName= declaration.AttributeLists.SelectMany(y => y.Attributes.Where(z=> z.Name.ToString()=="Views")).First().ArgumentList.Arguments.ToString();
            modelName = modelName.Substring(7, modelName.Length-8);
            ClassDeclarationSyntax modelClass = syntaxTrees.Where(x => x.Identifier.ToString() == modelName).First();
            WriteLine("    public partial class " + declaration.Identifier.Text + " {");
        
            foreach(PropertyDeclarationSyntax prp in modelClass.DescendantNodes().OfType<PropertyDeclarationSyntax>()){
                WriteLine("        public " + prp.Type + " " + prp.Identifier + " {");
                WriteLine("            get => Model." + prp.Identifier + ";");
                WriteLine("            set");
                WriteLine("            {");
                WriteLine("                Model." + prp.Identifier + " = value;");
                WriteLine("                RaisePropertyChanged(() => " + prp.Identifier + ");");
                WriteLine("            }");
                WriteLine("        }\n");
            }
            WriteLine("    }");
            if(namespaceNode != null) {
		        Write("}");
	        }
        }
    #>
