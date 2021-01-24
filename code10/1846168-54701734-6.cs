    class Node
    {
        public string Data { get; set; }
        public Node Next { get; set; }
    }
    class LinkedList
    {
        public Node Head { get; private set; }
        public void Add(string data)
        {
            var node = new Node {Data = data};
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                var current = Head;
                while (current.Next != null) current = current.Next;
                current.Next = node;
            }
        }
        public void RemoveAfterIndex(int index)
        {
            if (index < -1) return;
            if (index == -1)
            {
                Head = Head.Next;
                return;
            }
            var current = Head;
            var count = 0;
            while (count < index && current.Next != null)
            {
                current = current.Next;
                count++;
            }
            current.Next = current.Next?.Next;
        }
        public void WriteNodes()
        {
            var current = Head;
            var index = 0;
            while (current != null)
            {
                Console.WriteLine(current.Data.PadRight(10) + $" (index {index++})");
                current = current.Next;
            }
        }
    }
