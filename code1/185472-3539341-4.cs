    struct Foo
    {
        int i;
    
        public void Test()
        {
            i++;
        }
    }
    
    static void update(ref Foo foo)
    {
        foo.Test();
    }
