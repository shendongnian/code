    static class Program {
        static void Write(object message) {
            Console.WriteLine(Thread.CurrentThread.Name + ": " + message);
        }
        static void Main() {
            Thread.CurrentThread.Name = "Reader";
            Thread writer = new Thread(WriterLoop);
            writer.Name = "Writer";
            var queue = new SizeQueue<int>(100);
            writer.Start(queue);
            // reader loop - note this can run parallel
            // to the writer
            for (int i = 0; i < 100; i++) {
                if (i % 10 == 9) Write(i);
                queue.Enqueue(i);
                Thread.Sleep(5); // pretend it takes time
            }
            queue.Close();
            Write("exiting");
        }
        static void WriterLoop(object state) {
            var queue = (SizeQueue<int>)state;
            int i;
            while (queue.TryDequeue(out i)) {
                if(i%10==9) Write(i);
                Thread.Sleep(10); // pretend it takes time
            }
            Write("exiting");
        }
    }
