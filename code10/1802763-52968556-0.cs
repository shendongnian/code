         public void Print()
        {
            while (this.count > 0)
            {
                Console.Write(firstNode.Data + "->");
                if (firstNode.Next != null)
                    firstNode = firstNode.Next;
                count--;
            }
        }
