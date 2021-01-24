csharp
using FluentArgs;
using System;
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FluentArgsBuilder.New()
                .DefaultConfigs()
                .Parameter("-r", "--read")
                    .WithDescription("Input file to be processed.")
                    .IsRequired()
                .Flag("-v", "--verbose")
                    .WithDescription("Prints all messages to standard output.")
                .Call(verbose => inputFile =>
                {
                    /* Application code */
                    if (verbose)
                    {
                        Console.WriteLine("Filename: {0}", inputFile);
                    }
                })
                .Parse(args);
        }
    }
}
Possible calls:
 - `myapp -r myfile.txt`
 - `myapp --read myfile.txt -v`
 - `myapp --verbose - myfile.txt`
 - etc.
