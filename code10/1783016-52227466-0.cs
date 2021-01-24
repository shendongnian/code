    using System.Diagnostics;
    namespace MyLibrary
    {
        /// <summary>
        /// This is a shared library that returns the assemblies version
        /// </summary>
        public class SharedLib
        {
            public string GetProductVersion()
            {
                System.Reflection.Assembly assembly = 
                  System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.ProductVersion;
                return version;
            }
        }
     }
