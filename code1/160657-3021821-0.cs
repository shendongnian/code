    Stack<Containerl> stack = new Stack<Container>();
    Container toBeSelected = ... my object to be selected after deletion ...
    while (toBeSelected != null)
    {
        stack.Push(toBeSelected);
        toBeSelected = toBeSelected.Parent;
    }
