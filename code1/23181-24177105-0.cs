    private static void MeasureTime()
        {
            var array = new int[10000];
            var list = array.ToList();
            Console.WriteLine("Array size: {0}", array.Length);
            Console.WriteLine("Array For loop ......");
            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < array.Length; i++)
            {
                Thread.Sleep(1);
            }
            stopWatch.Stop();
            Console.WriteLine("Time take to run the for loop is {0} millisecond", stopWatch.ElapsedMilliseconds);
            Console.WriteLine(" ");
            Console.WriteLine("Array Foreach loop ......");
            var stopWatch1 = Stopwatch.StartNew();
            foreach (var item in array)
            {
                Thread.Sleep(1);
            }
            stopWatch1.Stop();
            Console.WriteLine("Time take to run the foreach loop is {0} millisecond", stopWatch1.ElapsedMilliseconds);
            Console.WriteLine(" ");
            Console.WriteLine("List For loop ......");
            var stopWatch2 = Stopwatch.StartNew();
            for (int i = 0; i < list.Count; i++)
            {
                Thread.Sleep(1);
            }
            stopWatch2.Stop();
            Console.WriteLine("Time take to run the for loop is {0} millisecond", stopWatch2.ElapsedMilliseconds);
            Console.WriteLine(" ");
            Console.WriteLine("List Foreach loop ......");
            var stopWatch3 = Stopwatch.StartNew();
            foreach (var item in list)
            {
                Thread.Sleep(1);
            }
            stopWatch3.Stop();
            Console.WriteLine("Time take to run the foreach loop is {0} millisecond", stopWatch3.ElapsedMilliseconds);
        }
