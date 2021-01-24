    using System;
    using System.Threading.Tasks;
    namespace ConsoleApp10
    {
        class Program
        {
            static void Main()
            {
                var test = new TaskCompletionSource<int>();
                Task.Run(() => Parallel.Invoke(
                    () => printValue(test.Task),
                    () => printValue(test.Task),
                    () => printValue(test.Task)));
                Console.WriteLine("Tasks are all waiting on the value; press return to continue.");
                Console.ReadLine();
                test.SetResult(42); // Or test.SetCanceled() to cancel it.
                Console.WriteLine("Set result to 42 (or cancelled)");
                Console.ReadLine();
            }
            static void printValue(Task<int> task)
            {
                try
                {
                    Console.WriteLine(task.Result);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Task received exception: " + exception.InnerException.Message);
                }
            }
        }
    }
