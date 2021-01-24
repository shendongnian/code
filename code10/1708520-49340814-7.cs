    using System;  
    using System.IO;   
    using System.Diagnostics;                                                                         
    using System.Reflection;
        class Program
        {
        static void Main(string []args)
        {
        try
        {
        
        if(args.Length!=0)
        {
        string executable=args[2];
       /*uncomment the below three lines if the exe file is in the Assets  
        folder of the project and not installed with the system*/         
        /*string path=Assembly.GetExecutingAssembly().CodeBase;
        string directory=Path.GetDirectoryName(path);
        process.Start(directory+"\\"+executable);*/
        Process.Start(executable);
        }
        }
        catch(Exception e)
        {
        Console.WriteLine(e.Message);
        Console.ReadLine();
        }
                                                                                          
        }
        }
