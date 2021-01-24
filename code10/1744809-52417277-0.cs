     /// <summary>
        /// We must calculate horizontal distance.
        /// Each node along with its hd shall be queued.
        /// Add hd and values in one hashset.
        /// </summary>
        /// <param name="root"></param>
        public void VerticalOrderTraversal(Node<T> root)
        {
            if (root == null)
                return;
            int hd = 0;
            Queue<Tuple<Node<T>,int>> q = new Queue<Tuple<Node<T>,int>>();
            Dictionary<int, HashSet<T>> ht = new Dictionary<int, HashSet<T>>();
            q.Enqueue(new Tuple<Node<T>, int>(root,hd));
            ht[hd] = new HashSet<T>();
            ht[hd].Add(root.Data);
            while (q.Count > 0)
            {
                Tuple<Node<T>, int> current = q.Peek();
                q.Dequeue();
                if (current.Item1.leftNode != null)
                {
                    if (!ht.ContainsKey(current.Item2 -1))
                    {
                        ht[current.Item2 - 1] = new HashSet<T>();
                        ht[current.Item2 - 1].Add(current.Item1.leftNode.Data);
                    }
                    else
                    {
                        ht[current.Item2 - 1].Add(current.Item1.leftNode.Data);
                    }
                    q.Enqueue(new Tuple<Node<T>, int>(current.Item1.leftNode, current.Item2 - 1));
                }
                if (current.Item1.rightNode != null)
                {
                    if (!ht.ContainsKey(current.Item2 + 1))
                    {
                        ht[current.Item2 + 1] = new HashSet<T>();
                        ht[current.Item2 + 1].Add(current.Item1.rightNode.Data);
                    }
                    else
                    {
                        ht[current.Item2 + 1].Add(current.Item1.rightNode.Data);
                    }
                    q.Enqueue(new Tuple<Node<T>, int>(current.Item1.rightNode, current.Item2 + 1));
                }
            }
            foreach (int key in ht.Keys)
            {
                foreach (T data in ht[key])
                {
                    Console.WriteLine("Vertical Level " + key + " value " + data);
                }
            }
        }
