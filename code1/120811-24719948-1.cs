            public void ReverseRecursive()
            {
                if (null == first)
                {
                    return;
                }
                if (null == first.Next)
                {
                    return;
                }
                last = first;
                first = this.ReverseRecursive(first);
            }
            private LinkedListNode<T> ReverseRecursive(LinkedListNode<T> node)
            {
                Debug.Assert(node != null);
                var adjNode = node.Next;
                if (adjNode == null)
                {
                    return node;
                }
                var rf = this.ReverseRecursive(adjNode);
                adjNode.Next = node;
                node.Next = null;
                return rf;
            }
