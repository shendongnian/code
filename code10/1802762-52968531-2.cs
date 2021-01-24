            public object Merge(List a, List b)
        {
            Node bNode = b.firstNode;
            while (bNode != null)
            {
                a.Add(bNode.Data);
                bNode = bNode.Next;
            }
            return a;
        }
