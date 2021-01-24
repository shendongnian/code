    public void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            using (var foo = new DisposableFoo())
            using (var bar = new DisposableBar())
            {
                 foo.SomeFunc = x => bar.DoSomethingWithX(x);
                 _foos.Add(foo);
            }
        }
    }
