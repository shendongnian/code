    using System;
    using System.Text;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    using System.Security;
    using Model; // this is my application Model with my own classes
    public static class ScriptRunner
    {
        private static string s_scripts_directory = "Scripts";
        static ScriptRunner()
        {
            if (!Directory.Exists(s_scripts_directory))
            {
                Directory.CreateDirectory(s_scripts_directory);
            }
        }
        /// <summary>
        /// Load a C# script fie
        /// </summary>
        /// <param name="filename">file to load</param>
        /// <returns>file content</returns>
        public static string LoadScript(string filename)
        {
            StringBuilder str = new StringBuilder();
            string path = s_scripts_directory + "/" + filename;
            if (File.Exists(filename))
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        str.AppendLine(line);
                    }
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// Compiles the source_code 
        /// </summary>
        /// <param name="source_code">source_code must implements IScript interface</param>
        /// <returns>compiled Assembly</returns>
        public static CompilerResults CompileCode(string source_code)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters options = new CompilerParameters();
            options.GenerateExecutable = false;  // generate a Class Library assembly
            options.GenerateInMemory = true;     // so we don;t have to delete it from disk
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                options.ReferencedAssemblies.Add(assembly.Location);
            }
            return provider.CompileAssemblyFromSource(options, source_code);
        }
        /// <summary>
        /// Execute the IScriptRunner.Run method in the compiled_assembly
        /// </summary>
        /// <param name="compiled_assembly">compiled assembly</param>
        /// <param name="args">method arguments</param>
        /// <returns>object returned</returns>
        public static object Run(Assembly compiled_assembly, object[] args, PermissionSet permission_set)
        {
            if (compiled_assembly != null)
            {
                // security is not implemented yet !NIY
                // using Utilties.PrivateStorage was can save but not diaplay in Notepad
                // plus the output is saved in C:\Users\<user>\AppData\Local\IsolatedStorage\...
                // no contral over where to save make QuranCode unportable applicaton, which is a no no
                //// restrict code security
                //permission_set.PermitOnly();
                foreach (Type type in compiled_assembly.GetExportedTypes())
                {
                    foreach (Type interface_type in type.GetInterfaces())
                    {
                        if (interface_type == typeof(IScriptRunner))
                        {
                            ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
                            if ((constructor != null) && (constructor.IsPublic))
                            {
                                // construct object using default constructor
                                IScriptRunner obj = constructor.Invoke(null) as IScriptRunner;
                                if (obj != null)
                                {
                                    return obj.Run(args);
                                }
                                else
                                {
                                    throw new Exception("Invalid C# code!");
                                }
                            }
                            else
                            {
                                throw new Exception("No default constructor was found!");
                            }
                        }
                        else
                        {
                            throw new Exception("IScriptRunner is not implemented!");
                        }
                    }
                }
                // revert security restrictions
                //CodeAccessPermission.RevertPermitOnly();
            }
            return null;
        }
        /// <summary>
        /// Execute a public static method_name(args) in compiled_assembly
        /// </summary>
        /// <param name="compiled_assembly">compiled assembly</param>
        /// <param name="methode_name">method to execute</param>
        /// <param name="args">method arguments</param>
        /// <returns>method execution result</returns>
        public static object ExecuteStaticMethod(Assembly compiled_assembly, string methode_name, object[] args)
        {
            if (compiled_assembly != null)
            {
                foreach (Type type in compiled_assembly.GetTypes())
                {
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.Name == methode_name)
                        {
                            if ((method != null) && (method.IsPublic) && (method.IsStatic))
                            {
                                return method.Invoke(null, args);
                            }
                            else
                            {
                                throw new Exception("Cannot invoke method :" + methode_name);
                            }
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Execute a public method_name(args) in compiled_assembly
        /// </summary>
        /// <param name="compiled_assembly">compiled assembly</param>
        /// <param name="methode_name">method to execute</param>
        /// <param name="args">method arguments</param>
        /// <returns>method execution result</returns>
        public static object ExecuteInstanceMethod(Assembly compiled_assembly, string methode_name, object[] args)
        {
            if (compiled_assembly != null)
            {
                foreach (Type type in compiled_assembly.GetTypes())
                {
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.Name == methode_name)
                        {
                            if ((method != null) && (method.IsPublic))
                            {
                                object obj = Activator.CreateInstance(type, null);
                                return method.Invoke(obj, args);
                            }
                            else
                            {
                                throw new Exception("Cannot invoke method :" + methode_name);
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
