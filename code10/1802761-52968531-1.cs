        public void Print()
        {
            Node node = firstNode;
            for (int i = 0; i < this.count; i++)
            {
                Console.Write(node.Data + "->");
                if (node.Next != null)
                    node = node.Next;
            }
        }
