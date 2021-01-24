    using System;
    using System.Threading.Tasks;
    namespace GenericException
    {
        public static class FuncHelpers
        {
            public static async Task<T> TryNTimesAsync<T,TException>(this Func<Task<T>> func, int n) where TException : Exception
            {
                while(n --> 0)
                {
                    try
                    {
                        return await func();
                    }
                    catch(TException)
                    {
                        if(n < 0)
                            throw;
                    }
                }
                return default(T);
            }
            public static async Task TryNTimesAsync<TException>(this Func<Task> func, int n) where TException : Exception
            {
                while(n --> 0)
                {
                    try
                    {
                        await func();
                    }
                    catch(TException)
                    {
                        if(n <= 0) throw;
                    }
                }
            }
            public static T TryNTimes<T,TException>(this Func<T> func, int n) where TException : Exception
            {
                while(n --> 0)
                {
                    try
                    {
                        return func();
                    }
                    catch(TException)
                    {
                        if(n <= 0) throw;
                    }
                }
                return default(T);
            }
        }
        class Program
        {
            static Task AddTwoNumbersAsync(int num1, int num2)
            {
                var task = new Task(() =>
                {
                    if(num1 % 2 == 0) throw new ArgumentException($"{nameof(num1)} must be odd");
                    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                });
                task.Start();
                return task;
            }
            static async Task Main(string[] args)
            {
                Func<Task> addTask = () => AddTwoNumbersAsync(2, 4);
                Console.WriteLine("trying to add non async");
                var taskResult = addTask.TryNTimes<Task, ArgumentException>(5);
                Console.WriteLine("trying to add async");
                try
                {
                    await addTask.TryNTimesAsync<ArgumentException>(5);
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("There was an error trying to add async");
                }
            }
        }
    }
