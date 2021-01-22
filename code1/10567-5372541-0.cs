    using System;
    using System.Diagnostics;
    
    namespace OpenFiles
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var openFiles = VmcController.Services.DetectOpenFiles.GetOpenFilesEnumerator(Process.GetCurrentProcess().Id))
                {
                    while (openFiles.MoveNext())
                    {
                        Console.WriteLine(openFiles.Current);
                    }
                }
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
