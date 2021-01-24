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
        public void RemoveAfter(int nodeNumber)
        {
            if (nodeNumber < 1) return;
            var current = Head;
            var count = 1;
            while (count < nodeNumber && current.Next != null)
            {
                current = current.Next;
                count++;
            }
            if (count == nodeNumber)
            {
                current.Next = current.Next?.Next;
            }
        }
        public void WriteNodes()
        {
            var current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
