       static void Main(string[] args)
        {
            ObservableQueue<string> observableQueue = new ObservableQueue<string>();
            observableQueue.EnQueued += ObservableQueue_EnQueued;
            observableQueue.DeQueued += ObservableQueue_DeQueued;
            observableQueue.Enqueue("abc");
            observableQueue.Dequeue();
         
            Console.Read();
        }
