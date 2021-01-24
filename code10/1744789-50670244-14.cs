    IEnumerable<T> enumerate(Node<T> root)
    {
        var stack = new Stack<Node<T>>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node == null)
                continue;
            yield return node.Key;
            stack.Push(node.RightChildNode);
            stack.Push(node.LeftChildNode);
        }
    }
