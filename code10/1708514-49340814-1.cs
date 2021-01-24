      using System;                                                                           using System.Diagnostics;
    class Program
    {
    static void Main(string []args)
    {
    try
    {
    
    if(args.Length!=0)
    {
    string executable=args[2];
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
