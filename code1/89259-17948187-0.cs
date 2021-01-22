        static void Main(string[] args)
        {
            LinkedList<string> ll = new LinkedList<string>();
            ll.AddLast("uno");
            ll.AddLast("dos");
            ll.AddLast("tres");
            ll.Remove(ll.Find("uno")); // Remove
            foreach (string item in sl)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
