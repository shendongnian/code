    static void Main()
    {
        En en = new En();
        Task.Factory.StartNew(() =>
            {
                foreach (int i in en)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("A:" + i.ToString());
                }
            });
        Task.Factory.StartNew(() =>
        {
            foreach (int i in en)
            {
                Thread.Sleep(10);
                Console.WriteLine("B:" +i.ToString());
            }
        });
        Console.ReadLine();
    }
    public class En : IEnumerable
    {
        object _lock = new object();
        static int i = 0;
        public IEnumerator GetEnumerator()
        {
            lock (_lock)
            {
                while (true)
                {
                    if (i < 10)
                        yield return i++;
                    else
                        yield break;
                }
            }
        }
    }
