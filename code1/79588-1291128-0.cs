    using System;
    using System.Runtime.InteropServices;
    using EnvDTE80;
    
    namespace SORemoteBuild
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                // Get an instance of the currently running Visual Studio IDE.
                EnvDTE80.DTE2 dte2;
                dte2 = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.
                                          GetActiveObject("VisualStudio.DTE.9.0");
                dte2.Solution.SolutionBuild.Build(true);
            }
        }
    
        public class MessageFilter : IOleMessageFilter
        {
            // ... Continues at http://msdn.microsoft.com/en-us/library/ms228772.aspx
