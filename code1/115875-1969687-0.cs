    var stack = new Stack<NestedLine>();
    foreach (var line : lines) {
        while (stack.Count > line.Level) {
            // Pop items until the top element is one up from current level
            stack.Pop()
        }
        var child = new NestedLine{Id = line.Id};
        if (stack.Count > 0) {
            // if there is a parent, add the child to its children
            stack.Peek().Children.Add(child);
        }
        // add current line as the deepest item
        stack.Push(child);
    }
    NestedLine root;
    while (stack.Count) {
        root = stack.Pop();
    }
