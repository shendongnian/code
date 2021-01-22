    public class Test
    {
        public void Display(int index)
        {
            foreach (int i in listInt())
            {
                Console.WriteLine("Thread {0} says: {1}", index, i);
                Thread.Sleep(1);
            }
        }
        public IEnumerable<int> listInt()
        {
            for (int i = 0; i < 5; i++)
            {
                yield return i;
            }
        }
    }
    class MainApp
    {
        static void Main()
        {
            Test test = new Test();
            for (int i = 0; i < 4; i++)
            {
                int x = i;
                Thread t = new Thread(p => { test.Display(x); });
                t.Start();
            }
            // Wait for user
            Console.ReadKey();
        }
    }
