    class Processor<T> {
        Action<T> action;
        Queue<T> queue = new Queue<T>();
        public Processor(Action<T> action) {
            this.action = action;
            new Thread(new ThreadStart(ThreadProc)).Start();
        }
        public void Queue(T data) {
            lock (queue) {
                queue.Enqueue(data);
                Monitor.Pulse(queue); 
            }
            
        }
        void ThreadProc() {
            Monitor.Enter(queue);
            Queue<T> copy;
            while (true) {
                 
                if (queue.Count == 0) {
                    Monitor.Wait(queue);
                }
                copy = new Queue<T>(queue);
                queue.Clear();
                Monitor.Exit(queue);
                foreach (var item in copy) {
                    action(item); 
                }
                Monitor.Enter(queue); 
            }
        }
    }
    
    class Program {
        static void Main(string[] args) {
            Processor<int> p = new Processor<int>((data) => { Console.WriteLine(data);  });
            p.Queue(1);
            p.Queue(2); 
            Console.Read();
            p.Queue(3);
        }
    }
