    class Program {
        static readonly Exception _test = new Exception("test");
        static void Main(string[] args) {
            ThreadPool.SetMinThreads(10, 8);
            var random = new Random();
            int num1 = 0;
            int num2 = 0;
            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++) {
                tasks.Add(Task.Run(() => {
                    try {
                        if (random.Next(0, 2) == 0) {
                            Interlocked.Increment(ref num1);
                            Throw1();
                        }
                        else {
                            Interlocked.Increment(ref num2);
                            Throw2();
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex);
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("num1: " + num1);
            Console.WriteLine("num2: " + num2);
            Console.ReadKey();
        }
        static void Throw1() {
            throw _test;
        }
        static void Throw2() {
            throw _test;
        }
    }
