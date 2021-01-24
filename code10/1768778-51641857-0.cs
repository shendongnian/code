    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            public static void Main(string[] args)
            {
                IEnumerable<string> filenames = Enumerable.Range(1, 100).Select(x => x.ToString());
                Parallel.ForEach(
                    filenames,
                    new ParallelOptions { MaxDegreeOfParallelism = 4},
                    download
                );
            }
            static void download(string filepath)
            {
                Console.WriteLine("Downloading " + filepath);
                Thread.Sleep(1000); // Simulate downloading time.
                Console.WriteLine("Downloaded " + filepath);
            }
        }
    }
