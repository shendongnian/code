    static void Main()
        {
            Object lockObj = new object();
            Queue<string> queue = new Queue<string>();
            Producer p = new Producer(queue);
            Comsumer c1 = new Comsumer(queue, lockObj, "c1");
            Comsumer c2 = new Comsumer(queue, lockObj, "c2");
            Thread t1 = new Thread(c1.consume);
            Thread t2 = new Thread(c2.consume);
            t1.Start();
            t2.Start();
            Thread t = new Thread(p.produce);
            t.Start();
            Console.ReadLine();
        }
    }
    public class Producer
    {
        Queue<string> queue;
        static int seq;
        public Producer(Queue<string> queue)
        {
            this.queue = queue;
        }
        public void produce()
        {
            while (seq++ < 1000) //just testinng 15 items
            {
                string item = "item" + seq;
                queue.Enqueue(item);
                Console.WriteLine("Producing {0}", item);                
            }
        }
    }
    public class Comsumer
    {
        Queue<string> queue;
        Object lockObject;
        string name;
        public Comsumer(Queue<string> queue, Object lockObject, string name)
        {
            this.queue = queue;
            this.lockObject = lockObject;
            this.name = name;
        }
        public void consume()
        {
            string item;
            while (true)
            {
                lock (lockObject)
                {
                    if (queue.Count == 0)
                    {
                        continue;
                    }
                    item = queue.Dequeue();
                    Console.WriteLine(" {0} Comsuming {1}", name, item);
                }                
            }
        }
    }
