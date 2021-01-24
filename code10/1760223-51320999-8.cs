    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using CommandLine;
    namespace ConsoleApp1
    {
        //Declare some options
        public class Options
        {
            //Format:
            //[Option(char shortoption, string longoption, Required = bool,  MetaValue = string, Min = int, Seperator = char, SetName = string)]
            //public <type> <name> { get; set; }
    
            [Option('r', "read", Required = true, HelpText = "Filename", Separator = ' ')]
            public IEnumerable<string> InputFiles { get; set; }
    
            [Option('e', "echo", Required = true, HelpText = "Echo message")]
            public string echo { get; set; }
    
        }
        class Program
        {
            static void Main(string[] args)
            {
                bool s = true;
                CommandLine.Parser.Default.ParseArguments<Options>(args).WithNotParsed<Options>((errs) => 
                {
                    foreach (Error e in errs)
                    {
                        Console.WriteLine("ERROR " + e.Tag.ToString());
                        s = e.StopsProcessing ? false : s;
                    }
                    if(!s)
                    {
                        return;
                    }
                }).WithParsed<Options>(opts => {
                    Console.WriteLine(opts.echo);
                    foreach(string filename in opts.InputFiles)
                    {
                        Console.WriteLine(File.ReadAllText(filename));
                    }
                });
    
            }
        }
    }
