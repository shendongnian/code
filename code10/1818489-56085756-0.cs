using System;
using Python.Runtime;
namespace Python_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Py.GIL())
            {
                dynamic os = Py.Import("os");
                dynamic dir = os.listdir();
                Console.WriteLine(dir);
                foreach (var d in dir)
                {
                    Console.WriteLine(d);
                }
            }
        }
    }
}
