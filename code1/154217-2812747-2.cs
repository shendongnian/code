using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread t = new System.Threading.Thread(MyThreadStart);
            t.Start("Hello");
            System.Console.ReadLine();
        }
        static void MyThreadStart(object state)
        {
            System.Console.WriteLine((string)state);
        }
    }
}
