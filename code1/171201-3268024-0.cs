    [SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
    internal static void LoadWebService(string webServiceAsmxUrl)
    {
        ParseUrl(webServiceAsmxUrl);
        System.Net.WebClient client = new System.Net.WebClient();
        // Connect To the web service
        System.IO.Stream stream = client.OpenRead(webServiceAsmxUrl + "?wsdl");
        // Now read the WSDL file describing a service.
        ServiceDescription description = ServiceDescription.Read(stream);
        ///// LOAD THE DOM /////////
        // Initialize a service description importer.
        ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
        importer.ProtocolName = "Soap12"; // Use SOAP 1.2.
        importer.AddServiceDescription(description, null, null);
        // Generate a proxy client.
        importer.Style = ServiceDescriptionImportStyle.Client;
        // Generate properties to represent primitive values.
        importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;
        // Initialize a Code-DOM tree into which we will import the service.
        CodeNamespace nmspace = new CodeNamespace();
        CodeCompileUnit unit1 = new CodeCompileUnit();
        unit1.Namespaces.Add(nmspace);
        // Import the service into the Code-DOM tree. This creates proxy code that uses the service.
        ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit1);
        if (warning == 0) // If zero then we are good to go
        {
            // Generate the proxy code
            CodeDomProvider provider1 = CodeDomProvider.CreateProvider("CSharp");
            // Compile the assembly proxy with the appropriate references
            string[] assemblyReferences = new string[5] { "System.dll", "System.Web.Services.dll", "System.Web.dll", "System.Xml.dll", "System.Data.dll" };
            CompilerParameters parms = new CompilerParameters(assemblyReferences);
            CompilerResults results = provider1.CompileAssemblyFromDom(parms, unit1);
            // Check For Errors
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError oops in results.Errors)
                {
                    System.Diagnostics.Debug.WriteLine("========Compiler error============");
                    System.Diagnostics.Debug.WriteLine(oops.ErrorText);
                }
                Console.WriteLine("Compile Error Occured calling webservice. Check Debug ouput window.");
            }
            // Finally, add the web service method to our list of methods to test
            //--------------------------------------------------------------------------------------------
            object service = results.CompiledAssembly.CreateInstance(serviceName);
            Type types = service.GetType();
            List<MethodInfo> listMethods = types.GetMethods().ToList();
    }
    }
