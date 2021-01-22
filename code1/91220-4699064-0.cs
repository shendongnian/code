        public static IEnumerator<BinarySearchTreeNode<T>> GetPostOrderTraverseEnumerator(BinarySearchTreeNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root");
            }
            Stack<BinarySearchTreeNode<T>> stack = new Stack<BinarySearchTreeNode<T>>();
            BinarySearchTreeNode<T> currentNode = root;
            // If the following flag is false, we need to visit the child nodes first
            // before we process the node.
            bool processNode = false;
            while (true)
            {
                // See if we need to visit child nodes first
                if (processNode != true)
                {
                    if (currentNode.Left != null)
                    {
                        // Remember to visit the current node later
                        stack.Push(currentNode);
                        if (currentNode.Right != null)
                        {
                            // Remember to visit the right child node later
                            stack.Push(currentNode.Right);
                        }
                        // Visit the left child
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else if (currentNode.Right != null)
                    {
                        // Remember to visit the current node later
                        stack.Push(currentNode);
                        // Visit the right child
                        currentNode = currentNode.Right;
                        continue;
                    }
                }
                // Process current node
                yield return currentNode;
                // See if we are done.
                if (stack.Count == 0)
                {
                    break;
                }
                // Get next node to visit from the stack
                BinarySearchTreeNode<T> previousNode = currentNode;
                currentNode = stack.Pop();
                // See if the next node should be processed or not
                // This can be determined by the fact that either of the current node's child nodes
                // has just been processed now.
                processNode = (previousNode == currentNode.Left || previousNode == currentNode.Right);
            }
        }
