    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.IO;
    
    namespace CommonClasses
    {
        /// <summary>
        /// Helper class to ensure the Common Language Runtime can dynamically load our referenced dlls.
        /// Because our components are called from COM via iexplore.exe the executing directory is likely to be something like 
        /// c:\program files\internet explorer\, which obviously doesn't contain our assemblies. This only seems to be a problem
        /// with the Enterprise Library so far, because it dynamically loads the assemblies it needs.
        /// This class helps by directing the CLR to use the directory of this assembly when it can't find the assembly 
        /// normally. The directory of this assembly is likely to be something like c:\program files\my program\
        /// and will contain all the dlls you could ask for.
        /// </summary>
        public static class AssemblyResolveAssistant
        {
    
            /// <summary>
            /// Records whether the AssemblyResolve event has been wired.
            /// </summary>
            private static bool _isWired = false;
    
            /// <summary>
            /// Add the handler to enable assemblies to be loaded from this assembly's directory, if it hasn't 
            /// already been added.
            /// </summary>
            public static void AddAssemblyResolveHandler()
            {
                if (!_isWired)
                {
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                    _isWired = true;
                }
            }
    
            /// <summary>
            /// Event handler that's called when the CLR tries to load an assembly and fails.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                Assembly result = null;
                // Get the directory where we think the assembly can be loaded from.
                string dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                AssemblyName assemblyName = new AssemblyName(args.Name);
                assemblyName.CodeBase = dirName;
                try
                {
                    //Load the assembly from the specified path.
                    result = Assembly.Load(assemblyName);
                }
                catch (Exception) { }
                //Return the loaded assembly, or null if assembly resolution failed.
                return result;
            }
        }
    }
