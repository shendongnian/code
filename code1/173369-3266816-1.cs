    void M(Ref<int> r)
    {
        if (r != null) // 3
        {
            Console.WriteLine(r.Value); // 2
            r.Value = 123; // 1
        }
    }
    ...
    int x = 0;
    M(new Ref<int>(y=>{x=y;}, ()=>x); // pass a 'ref' to x
