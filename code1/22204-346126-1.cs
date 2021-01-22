    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Microsoft.CSharp;
    
    namespace DynamicCodeApplication
    {
        class azCodeCompiler
        {
            private List<string> assemblies;
    
            public azCodeCompiler()
            {
                assemblies = new List<string>();
                scanAndCacheAssemblies();
            }
    
            public Assembly BuildAssembly(string code)
            {
    
                CodeDomProvider prov = CodeDomProvider.CreateProvider("CSharp");
                string[] references = new string[] { };   // Intentionally empty, using csc.rsp
                CompilerParameters cp = new CompilerParameters(references)
                                            {
                                                GenerateExecutable = false,
                                                GenerateInMemory = true
                                            };
                string path = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
                cp.CompilerOptions = "@" + path + @"\csc.rsp";
                CompilerResults cr = prov.CompileAssemblyFromSource(cp, code);
    
                foreach (CompilerError err in cr.Errors)
                {
                    Console.WriteLine(err.ToString());
                }
                return cr.CompiledAssembly;
            }
    
            public object ExecuteCode(string code,
                                      string namespacename, string classname,
                                      string functionname, bool isstatic, params object[] args)
            {
                object returnval = null;
                Assembly asm = BuildAssembly(code);
                object instance = null;
                Type type = null;
                if (isstatic)
                {
                    type = asm.GetType(namespacename + "." + classname);
                }
                else
                {
                    instance = asm.CreateInstance(namespacename + "." + classname);
                    type = instance.GetType();
                }
                MethodInfo method = type.GetMethod(functionname);
                returnval = method.Invoke(instance, args);
                return returnval;
            }
    
            private void scanAndCacheAssemblies()
            {
    
                /*
                foreach (string str in Directory.GetFiles(@"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727"))
                {
                    if (str.Contains(".dll"))
                    {
                        foreach (string st in str.Split(new char[] { '\\' }))
                        {
                            if (st.Contains(".dll"))
                            {
                                assemblies.Add(st);
                            }
                        }
                    }
                }
                 * */
                
                assemblies.Add("Accessibility.dll");
                assemblies.Add("AspNetMMCExt.dll");
                assemblies.Add("cscompmgd.dll");
                assemblies.Add("CustomMarshalers.dll");
                assemblies.Add("IEExecRemote.dll");
                assemblies.Add("IEHost.dll");
                assemblies.Add("IIEHost.dll");
                assemblies.Add("Microsoft.Build.Conversion.dll");
                assemblies.Add("Microsoft.Build.Engine.dll");
                assemblies.Add("Microsoft.Build.Framework.dll");
                assemblies.Add("Microsoft.Build.Tasks.dll");
                assemblies.Add("Microsoft.Build.Utilities.dll");
                assemblies.Add("Microsoft.Build.VisualJSharp.dll");
                assemblies.Add("Microsoft.CompactFramework.Build.Tasks.dll");
                assemblies.Add("Microsoft.JScript.dll");
                assemblies.Add("Microsoft.VisualBasic.Compatibility.Data.dll");
                assemblies.Add("Microsoft.VisualBasic.Compatibility.dll");
                assemblies.Add("Microsoft.VisualBasic.dll");
                assemblies.Add("Microsoft.VisualBasic.Vsa.dll");
                assemblies.Add("Microsoft.Vsa.dll");
                assemblies.Add("Microsoft.Vsa.Vb.CodeDOMProcessor.dll");
                assemblies.Add("Microsoft_VsaVb.dll");
                assemblies.Add("mscorlib.dll");
                assemblies.Add("sysglobl.dll");
                assemblies.Add("System.configuration.dll");
                assemblies.Add("System.Configuration.Install.dll");
                assemblies.Add("System.Data.dll");
                assemblies.Add("System.Data.OracleClient.dll");
                assemblies.Add("System.Data.SqlXml.dll");
                assemblies.Add("System.Deployment.dll");
                assemblies.Add("System.Design.dll");
                assemblies.Add("System.DirectoryServices.dll");
                assemblies.Add("System.DirectoryServices.Protocols.dll");
                assemblies.Add("System.dll");
                assemblies.Add("System.Drawing.Design.dll");
                assemblies.Add("System.Drawing.dll");
                assemblies.Add("System.EnterpriseServices.dll");
                assemblies.Add("System.Management.dll");
                assemblies.Add("System.Messaging.dll");
                assemblies.Add("System.Runtime.Remoting.dll");
                assemblies.Add("System.Runtime.Serialization.Formatters.Soap.dll");
                assemblies.Add("System.Security.dll");
                assemblies.Add("System.ServiceProcess.dll");
                assemblies.Add("System.Transactions.dll");
                assemblies.Add("System.Web.dll");
                assemblies.Add("System.Web.Mobile.dll");
                assemblies.Add("System.Web.RegularExpressions.dll");
                assemblies.Add("System.Web.Services.dll");
                assemblies.Add("System.Windows.Forms.dll");
                assemblies.Add("System.XML.dll");
                assemblies.Add("vjscor.dll");
                assemblies.Add("vjsjbc.dll");
                assemblies.Add("vjslib.dll");
                assemblies.Add("vjslibcw.dll");
                assemblies.Add("vjssupuilib.dll");
                assemblies.Add("vjsvwaux.dll");
                assemblies.Add("vjswfc.dll");
                assemblies.Add("VJSWfcBrowserStubLib.dll");
                assemblies.Add("vjswfccw.dll");
                assemblies.Add("vjswfchtml.dll");
                assemblies.Add("Accessibility.dll");
                assemblies.Add("AspNetMMCExt.dll");
                assemblies.Add("cscompmgd.dll");
                assemblies.Add("CustomMarshalers.dll");
                assemblies.Add("IEExecRemote.dll");
                assemblies.Add("IEHost.dll");
                assemblies.Add("IIEHost.dll");
                assemblies.Add("Microsoft.Build.Conversion.dll");
                assemblies.Add("Microsoft.Build.Engine.dll");
                assemblies.Add("Microsoft.Build.Framework.dll");
                assemblies.Add("Microsoft.Build.Tasks.dll");
                assemblies.Add("Microsoft.Build.Utilities.dll");
                assemblies.Add("Microsoft.Build.VisualJSharp.dll");
                assemblies.Add("Microsoft.CompactFramework.Build.Tasks.dll");
                assemblies.Add("Microsoft.JScript.dll");
                assemblies.Add("Microsoft.VisualBasic.Compatibility.Data.dll");
                assemblies.Add("Microsoft.VisualBasic.Compatibility.dll");
                assemblies.Add("Microsoft.VisualBasic.dll");
                assemblies.Add("Microsoft.VisualBasic.Vsa.dll");
                assemblies.Add("Microsoft.Vsa.dll");
                assemblies.Add("Microsoft.Vsa.Vb.CodeDOMProcessor.dll");
                assemblies.Add("Microsoft_VsaVb.dll");
                assemblies.Add("mscorlib.dll");
                assemblies.Add("sysglobl.dll");
                assemblies.Add("System.configuration.dll");
                assemblies.Add("System.Configuration.Install.dll");
                assemblies.Add("System.Data.dll");
                assemblies.Add("System.Data.OracleClient.dll");
                assemblies.Add("System.Data.SqlXml.dll");
                assemblies.Add("System.Deployment.dll");
                assemblies.Add("System.Design.dll");
                assemblies.Add("System.DirectoryServices.dll");
                assemblies.Add("System.DirectoryServices.Protocols.dll");
                assemblies.Add("System.dll");
                assemblies.Add("System.Drawing.Design.dll");
                assemblies.Add("System.Drawing.dll");
                assemblies.Add("System.EnterpriseServices.dll");
                assemblies.Add("System.Management.dll");
                assemblies.Add("System.Messaging.dll");
                assemblies.Add("System.Runtime.Remoting.dll");
                assemblies.Add("System.Runtime.Serialization.Formatters.Soap.dll");
                assemblies.Add("System.Security.dll");
                assemblies.Add("System.ServiceProcess.dll");
                assemblies.Add("System.Transactions.dll");
                assemblies.Add("System.Web.dll");
                assemblies.Add("System.Web.Mobile.dll");
                assemblies.Add("System.Web.RegularExpressions.dll");
                assemblies.Add("System.Web.Services.dll");
                assemblies.Add("System.Windows.Forms.dll");
                assemblies.Add("System.XML.dll");
                assemblies.Add("vjscor.dll");
                assemblies.Add("vjsjbc.dll");
                assemblies.Add("vjslib.dll");
                assemblies.Add("vjslibcw.dll");
                assemblies.Add("vjssupuilib.dll");
                assemblies.Add("vjsvwaux.dll");
                assemblies.Add("vjswfc.dll");
                assemblies.Add("VJSWfcBrowserStubLib.dll");
                assemblies.Add("vjswfccw.dll");
                assemblies.Add("vjswfchtml.dll");
    
                
                return;
            }
        }
    }
