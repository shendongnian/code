        System.Net.WebClient client = new System.Net.WebClient(); 
        string strUrl = @"http://localhost:xxxxx/Service.asmx?wsdl"; 
        System.IO.Stream stream = client.OpenRead(strUrl); 
 
        string serviceName = "Service"; 
 
        // Get a WSDL file describing a service. 
        ServiceDescription description = ServiceDescription.Read(stream); 
 
        ServiceDescriptionImporter importer = new ServiceDescriptionImporter(); 
        importer.ProtocolName = "Soap12";  // Use SOAP 1.2. 
        importer.AddServiceDescription(description, null, null); 
 
        // Generate a proxy client. 
        importer.Style = ServiceDescriptionImportStyle.Client; 
 
        // Generate properties to represent primitive values. 
        importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties; 
 
        // Initialize a Code-DOM tree into which we will import the service. 
        CodeNamespace nmspace = new CodeNamespace(); 
        CodeCompileUnit unit1 = new CodeCompileUnit(); 
        unit1.Namespaces.Add(nmspace); 
 
        // Import the service into the Code-DOM tree. This creates proxy code 
        // that uses the service. 
        ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit1); 
 
         if (warning == 0) 
         { 
            // Generate and print the proxy code in C#. 
            CodeDomProvider provider1 = CodeDomProvider.CreateProvider("CSharp"); 
 
            // Compile the assembly with the appropriate references 
            string[] assemblyReferences = new string[2] { "System.Web.Services.dll", "System.Xml.dll" }; 
            CompilerParameters parms = new CompilerParameters(assemblyReferences); 
            CompilerResults results = provider1.CompileAssemblyFromDom(parms, unit1); 
 
            foreach (CompilerError  oops in results.Errors) 
            { 
                Console.WriteLine("========Compiler error============"); 
                Console.WriteLine(oops.ErrorText); 
            } 
 
            //Invoke the web service method 
			foreach (PortType portType in description.PortTypes)
        	{
	            foreach (Operation operation in portType.Operations)
	            {
					try
					{
			            object o = results.CompiledAssembly.CreateInstance(serviceName); 
			            Type t = o.GetType(); 
			            Console.WriteLine(t.InvokeMember(operation.Name, System.Reflection.BindingFlags.InvokeMethod, null, o, null)); 
					}catch(Exception ex){
						Console.WriteLine(ex.Message);
					}
				}
			}
         } 
 
        else 
        { 
            // Print an error message. 
            Console.WriteLine("Warning: " + warning); 
        } 
