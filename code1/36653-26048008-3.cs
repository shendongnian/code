    string[] items = new string[] { "a", "b", "c", "d" };
    
    Stack<string> stack = new Stack<string>(items.Reverse());
        
    while(stack.Count > 1)
    {
      Console.WriteLine("{0},{1}", stack.Pop(), stack.Peek());
    }
