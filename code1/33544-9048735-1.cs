    class Program
    {
        static void Main(string[] args)
        {
            ListQueue<string> queue = new ListQueue<string>();
            Console.WriteLine("Item count in ListQueue: {0}", queue.Count);
            Console.WriteLine();
            for (int i = 1; i <= 10; i++)
            {
                var text = String.Format("Test{0}", i);
                queue.Enqueue(text);
                Console.WriteLine("Just enqueued: {0}", text);
            }
            Console.WriteLine();
            Console.WriteLine("Item count in ListQueue: {0}", queue.Count);
            Console.WriteLine();
            var peekText = queue.Peek();
            Console.WriteLine("Just peeked at: {0}", peekText);
            Console.WriteLine();
            var textToRemove = "Test5";
            queue.Remove(textToRemove);
            Console.WriteLine("Just removed: {0}", textToRemove);
            Console.WriteLine();
            var queueCount = queue.Count;
            for (int i = 0; i < queueCount; i++)
            {
                var text = queue.Dequeue();
                Console.WriteLine("Just dequeued: {0}", text);
            }
            Console.WriteLine();
            Console.WriteLine("Item count in ListQueue: {0}", queue.Count);
            Console.WriteLine();
            Console.WriteLine("Now try to ADD an item...should cause an exception.");
            queue.Add("shouldFail");
        }
    }
