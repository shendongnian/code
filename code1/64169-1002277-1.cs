using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BackgroundWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test 1");
            BackgroundWorker worker = new BackgroundWorker(BackgroundWork);
            worker.TaskCompleted += new EventHandler(worker_TaskCompleted);
            worker.BackgroundError += new EventHandler<BackgroundWorkerErrorEventArgs>(worker_BackgroundError);
            worker.Start();
            worker.Wait(-1);
            Console.WriteLine("Test 2");
            Console.WriteLine();
            // error case
            worker = new BackgroundWorker(BackgroundWorkWithError);
            worker.TaskCompleted += new EventHandler(worker_TaskCompleted);
            worker.BackgroundError += new EventHandler<BackgroundWorkerErrorEventArgs>(worker_BackgroundError);
            worker.Start();
            worker.Wait(-1);
            Console.ReadLine();
        }
        static void worker_BackgroundError(object sender, BackgroundWorkerErrorEventArgs e)
        {
            Console.WriteLine("Exception: " + e.Error.Message);
        }
        private static void BackgroundWorkWithError()
        {
            throw new Exception("Foo");
        }
        static void worker_TaskCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Completed");
        }
        private static void BackgroundWork()
        {
            Console.WriteLine("Hello!");
        }
    }
}
