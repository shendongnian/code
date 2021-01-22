    using System;
    using DocoptNet;
    namespace MyProgram
    {
        static class Program
        {
            static void Main(string[] args)
            {
                //Usage string
                string usage = @"This program does this thing.
    Usage:
      program set <something>
      program do <something> [-o <optionalthing>]
      program do <something> [somethingelse]";
                try
                {
                    var arguments = new Docopt().Apply(usage, args, version: "My program v0.1.0", exit: false);
                    foreach(var argument in arguments)
                        Console.WriteLine("{0} = {1}", argument.Key, argument.Value);
                }
                catch(Exception ex)
                {
                    //Parser errors are thrown as exceptions.
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
