    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("name\t1 thread\t4 threads");
            RunTest("no spacer", WorkerUsingHeap, () => new Data());
            var values = new int[] { -1, 0, 4, 8, 12, 16, 20 };
            foreach (var sv in values)
            {
                var v = sv;
                RunTest(string.Format(v == -1 ? "null spacer" : "{0}B spacer", v), WorkerUsingHeap, () => new DataWithSpacer(v));
            }
            Console.ReadLine();
        }
        public static void RunTest(string name, ParameterizedThreadStart worker, Func<object> fo)
        {
            var start = DateTime.UtcNow;
            RunOneThread(worker, fo);
            var middle = DateTime.UtcNow;
            RunFourThreads(worker, fo);
            var end = DateTime.UtcNow;
            Console.WriteLine("{0}\t{1}\t{2}", name, middle-start, end-middle);
        }
        public static void RunOneThread(ParameterizedThreadStart worker, Func<object> fo)
        {
            var data = fo();
            var threadOne = new Thread(worker);
            threadOne.Start(data);
            threadOne.Join();
        }
        public static void RunFourThreads(ParameterizedThreadStart worker, Func<object> fo)
        {
            var data1 = fo();
            var data2 = fo();
            var data3 = fo();
            var data4 = fo();
            var threadOne = new Thread(worker);
            threadOne.Start(data1);
            var threadTwo = new Thread(worker);
            threadTwo.Start(data2);
            var threadThree = new Thread(worker);
            threadThree.Start(data3);
            var threadFour = new Thread(worker);
            threadFour.Start(data4);
            threadOne.Join();
            threadTwo.Join();
            threadThree.Join();
            threadFour.Join();
        }
        static void WorkerUsingHeap(object state)
        {
            var data = state as Data;
            for (int count = 0; count < 500000000; count++)
            {
                var property = data.Property;
                data.Property = property + 1;
            }
        }
        public class Data
        {
            public int Property { get; set; }
        }
        public class DataWithSpacer : Data
        {
            public DataWithSpacer(int size) { Spacer = size == 0 ? null : new byte[size]; }
            public byte[] Spacer;
        }
    }
