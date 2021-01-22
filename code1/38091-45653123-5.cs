    using System;
    using System.Configuration;
    using System.IO;
    
    namespace ConfigInterpollation
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Console_Tests().Run_Tests();
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }        
        }
    
        internal class Console_Tests
        {
            public void Run_Tests()
            {
                Test_Environment_Variables();
                Test_Interpollation();
                Test_Static_Class();
            }
            private void Test_Environment_Variables()
            {
                string ConfigPath = ConfigurationManager.AppSettings["EnvironmentVariableExample"];
                string ExpandedPath = Environment.ExpandEnvironmentVariables(ConfigPath).Replace("\"", "");
                Console.WriteLine($"Using environment variables {ExpandedPath}");
            }
    
            private void Test_Interpollation()
            {
                string ConfigPath = ConfigurationManager.AppSettings["InterpollationExample"];
                string SolutionPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string ExpandedPath = string.Format(ConfigPath, SolutionPath.ToString());
                Console.WriteLine($"Using interpollation {ExpandedPath}");
            }
    
            private void Test_Static_Class()
            {
                Console.WriteLine($"Using a static config class {Configuration.BinPath}");
            }
        }
    
        static class Configuration
        {
            public static string BinPath
            {
                get
                {
                    string ConfigPath = ConfigurationManager.AppSettings["StaticClassExample"];
                    string SolutionPath = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                    return SolutionPath + ConfigPath;
                }
            }
        }
    }
