    class History
    {
        private class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }
            public Node(string data) { Data = data; }
        }
        private Node head;
        private Node current;
        public void VisitNewPage(string desc)
        {
            // Create a node for this page
            var node = new Node(desc);
            // If it's our first page, set the head
            if (head == null) head = node;
            // Update our current.Next pointer
            if (current != null)
            {
                current.Next = node;
            }
            // Set this page as our current page
            current = node;
        }
        public void MoveBackwards()
        {
            // Can't move backwards from the head
            if (current == head) return;
            var previous = head;
            // Find the node that's behind (pointing to) the current node
            while (previous.Next != current)
            {
                previous = previous.Next;
            }
            // Make that node our new current
            current = previous;
        }
        public void MoveForwards()
        {
            // Just move to the next node
            if (current.Next != null) current = current.Next;
        }
        public void PrintCurrent()
        {
            Console.WriteLine($"You are on page: {current.Data}");
        }
        public void PrintHistory()
        {
            Console.WriteLine("\nBrowsing History");
            var node = head;
            if (node == null)
            {
                Console.WriteLine("[Empty]");
                return;
            }
            // Print previous pages
            while (node != current)
            {
                Console.WriteLine($" - {node.Data}");
                node = node.Next;
            }
            // Print current page in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" - {node.Data}");
            Console.ResetColor();
            node = node.Next;
            // Print next pages
            while (node != null)
            {
                Console.WriteLine($" - {node.Data}");
                node = node.Next;
            }
            Console.WriteLine();
        }
    }
