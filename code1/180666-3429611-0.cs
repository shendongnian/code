    public void DoSomeWorkWith(Foo x)
    {
        var firstItem = new Tuple<int, Foo>(0, x);
        var s = new Stack<Tuple<int, Foo>>();
        s.Push(firstItem);
        while (s.Any())
        {
            var current = s.Pop();
            DoSomeBusiness(current.Item2);
            DoSomeMoreBusiness(current.Item2);
            Log(current.Item1, current.Item2.id);
            foreach (Foo child in current.Item2.Childs)
                s.Push(new Tuple<int, Foo>(current.Item1 + 1, child));
        }
    }
