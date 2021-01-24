            if (v < start.Value)
            {
                if (start.LeftChild != null)
                {
                    start.LeftChild = InsertNewNode(start.LeftChild, v);
                }
                else
                {
                    start.LeftChild = new Node(v);
                    size++;
                }
            }
            else if (v > start.Value)
            {
                if (start.RightChild != null)
                {
                    start.RightChild = InsertNewNode(start.RightChild, v);
                }
                else
                {
                    start.RightChild = new Node(v);
                    size++;
                }
            }
