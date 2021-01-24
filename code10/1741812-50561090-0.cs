    class Program
        {
            static void Main(string[] args)
            {
                Task.Run(() => new Work().DoWork(1));
                Task.Run(() => new Work().DoWork(2));
    
                Console.ReadLine();
            }
    
            public class Work
            {
                public void DoWork(int taskNumber)
                {
                    for(int i=0; i < 100; i++)
                    {
                        Console.WriteLine("Task {0} Value {1}", taskNumber, i);
                    }
                }
            }
        }
