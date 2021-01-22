    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Net;
    using System.Security.Permissions;
    using System.Web.Services.Description;
    using System.Xml.Serialization;
    
    namespace ConnectionLib
    {
        internal class WsProxy
        {
            [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
            internal static object CallWebService(
                string webServiceAsmxUrl,
                string serviceName,
                string methodName,
                object[] args)
            {
                var description = ReadServiceDescription(webServiceAsmxUrl);
    
                var compileUnit = CreateProxyCodeDom(description);
                if (compileUnit == null)
                {
                    return null;
                }
    
                var results = CompileProxyCode(compileUnit);
    
                // Finally, Invoke the web service method
                var wsvcClass = results.CompiledAssembly.CreateInstance(serviceName);
                var mi = wsvcClass.GetType().GetMethod(methodName);
                return mi.Invoke(wsvcClass, args);
            }
    
            private static ServiceDescription ReadServiceDescription(string webServiceAsmxUrl)
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(webServiceAsmxUrl + "?wsdl"))
                    {
                        return ServiceDescription.Read(stream);
                    }
                }
            }
    
            private static CodeCompileUnit CreateProxyCodeDom(ServiceDescription description)
            {
                var importer = new ServiceDescriptionImporter
                               {
                                   ProtocolName = "Soap12",
                                   Style = ServiceDescriptionImportStyle.Client,
                                   CodeGenerationOptions =
                                       CodeGenerationOptions.GenerateProperties
                               };
                importer.AddServiceDescription(description, null, null);
    
                // Initialize a Code-DOM tree into which we will import the service.
                var nmspace = new CodeNamespace();
                var compileUnit = new CodeCompileUnit();
                compileUnit.Namespaces.Add(nmspace);
    
                // Import the service into the Code-DOM tree. This creates proxy code
                // that uses the service.
                var warning = importer.Import(nmspace, compileUnit);
                return warning != 0 ? null : compileUnit;
            }
    
            private static CompilerResults CompileProxyCode(CodeCompileUnit compileUnit)
            {
                CompilerResults results;
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    var assemblyReferences = new[]
                                             {
                                                 "System.dll",
                                                 "System.Web.Services.dll",
                                                 "System.Web.dll", "System.Xml.dll",
                                                 "System.Data.dll"
                                             };
                    var parms = new CompilerParameters(assemblyReferences);
                    results = provider.CompileAssemblyFromDom(parms, compileUnit);
                }
    
                // Check For Errors
                if (results.Errors.Count == 0)
                {
                    return results;
                }
                
                foreach (CompilerError oops in results.Errors)
                {
                    Debug.WriteLine("========Compiler error============");
                    Debug.WriteLine(oops.ErrorText);
                }
    
                throw new Exception(
                    "Compile Error Occurred calling webservice. Check Debug output window.");
            }
        }
    }
