    class Program
    {
        public delegate int MyDelegate(List<int> someInts);
        class MainClass
        {
            static void Main()
            {
                List<int> someInts = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
                MyDelegate test = FinalResult;
                test.BeginInvoke(someInts, ar => 
                {
                    MyDelegate del = (MyDelegate)ar.AsyncState;
                    Console.WriteLine(del.EndInvoke(ar));
                }, test);
                Console.ReadKey(true);
            }
            public static int FinalResult(List<int> Mylist)
            {
                return Mylist.Sum();
            }
        }
    }
