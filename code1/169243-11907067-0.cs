    <#@ template debug="true" hostSpecific="true" #>
    <#@ Assembly Name="System.Core.dll" #>
    <#@ Assembly Name="System.Windows.Forms.dll" #>
    <#@ Assembly Name="System.Xml" #>
    <#@ Assembly Name="Microsoft.CSharp" #>
    <#@ output extension=".txt" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="System.Reflection" #>
    <#@ import namespace="System.Xml" #>
    <#@ import namespace="System.Xml.Serialization" #>
    <#@ import namespace="System.Xml.Schema" #>
    <#@ import namespace="System.CodeDom" #>
    <#@ import namespace="System.CodeDom.Compiler" #>
    <#@ import namespace="Microsoft.CSharp" #>
    <# 
    	// directory of this template
    	var outputDirectory = Path.GetDirectoryName(Host.TemplateFile);
    	
    	// iterate through each XSD file in our /Schema/ directory
        // and output the generated C# file in this directory.
    	foreach(var file in new DirectoryInfo(Host.ResolvePath("Schemas")).GetFiles("*.xsd")) {
    
    		// ouput file should be the directory of this template, with .Generated.cs
    		var outputFile = Path.Combine(outputDirectory, file.Name.Replace(".xsd", ".Generated.cs"));
    
    		// do it
    		File.WriteAllText(outputFile, GenerateFromXsd(file.FullName));
    	}
    #>
    <#+
    	private string GenerateFromXsd(string xsdFileName)
    	{
    		// load the xsd
    		XmlSchema xsd;
    		using (FileStream stream = new FileStream(xsdFileName, FileMode.Open, FileAccess.Read))
    		{
    			xsd = XmlSchema.Read(stream, null);
    		}
    
    		var xsds = new XmlSchemas();
    		xsds.Add(xsd);
    		xsds.Compile(null, true);
    
    		var schemaImporter = new XmlSchemaImporter(xsds);
    
    		// create the codedom
    		var codeNamespace = new CodeNamespace((string)System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("NamespaceHint"));
    		var codeExporter = new XmlCodeExporter(codeNamespace);
    
    		var maps = new List<object>();
    		foreach (XmlSchemaType schemaType in xsd.SchemaTypes.Values)
    		{
    			maps.Add(schemaImporter.ImportSchemaType(schemaType.QualifiedName));
    		}
    		foreach (XmlSchemaElement schemaElement in xsd.Elements.Values)
    		{
    			maps.Add(schemaImporter.ImportTypeMapping(schemaElement.QualifiedName));
    		}
    		foreach (XmlTypeMapping map in maps)
    		{
    			codeExporter.ExportTypeMapping(map);
    		}
    
    		// Check for invalid characters in identifiers
    		CodeGenerator.ValidateIdentifiers(codeNamespace);
    
    		// output the C# code
    		var codeProvider = new CSharpCodeProvider();
    
    		using (var writer = new StringWriter())
    		{
    			codeProvider.GenerateCodeFromNamespace(codeNamespace, writer, new CodeGeneratorOptions());
    			return writer.GetStringBuilder().ToString();
    		}
    	}
    #>
