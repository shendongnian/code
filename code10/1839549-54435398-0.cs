    class Program
    {
        static void Main(string[] args)
        {
            var asyncLock = new AsyncLock();
            // we need ToList here, since IEnumerable is lazy, 
            // and must be enumerated to produce values (tasks in this case)
            new[] { ('a', 0), ('b', 10), ('c', 20) }
                .Select(_ => WriteAsync(_.Item1, _.Item2, asyncLock))
                .ToList();
            Console.ReadLine();
        }
        static async Task WriteAsync(char c, int x, AsyncLock asyncLock)
        {
            for (var i = 0; i < 1000; i++)
            {
                using (await asyncLock.LockAsync())
                {
                    Console.SetCursorPosition(x, i);
                    Console.Write(c);
                }
                await Task.Delay(100);
            }
        }
    }
