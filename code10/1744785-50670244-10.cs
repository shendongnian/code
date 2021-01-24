    IEnumerable<T> enumerate(Node<T> root)
    {
        var stack = new Stack<Node<T>>();
        stack.Push(null); // Terminates the loop.
        stack.Push(root);
        while (true)
        {
            var node = stack.Pop();
            if (node == null)
                yield break;
            yield return node.Key;
            if (node.RightChildNode != null)
                stack.Push(node.RightChildNode);
            if (node.LeftChildNode != null)
                stack.Push(node.LeftChildNode);
        }
    }
