    using System;
    using Microsoft.SqlServer.Dts.Runtime.Wrapper;
     
    namespace ConsoleApplicationSSIS
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Loading SSIS Service...");
                //Application object allows load your SSIS package
                Application app = new Application();
                //In order to retrieve the status (success or failure) after running SSIS Package
                DTSExecResult result ;
                //Specify the location of SSIS package - dtsx file
                string SSISPackagePath = @"C:\Microsofts\BI\SSIS\ConsoleApplicationSSIS\IntegrationServiceScriptTask\Package.dtsx";
                //Load your package
                Package pckg = (Package)app.LoadPackage(SSISPackagePath,true,null);
                //Execute the package and retrieve result
                result  = pckg.Execute();
                //Print the status success or failure of your package
                Console.WriteLine("{0}", result.ToString());
                Console.ReadLine();
            }
        }
    } 
