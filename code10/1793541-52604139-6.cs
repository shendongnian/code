    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static async Task Main()
            {
                string filename = "Your filename here";
                Console.WriteLine(await ReadCharsAsync(filename, 100));
            }
        }
    }
