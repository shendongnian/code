    unsafe struct Foo
    {
        public fixed byte name[1024];
        public fixed int crop[4];
    }
    static unsafe void DumpCrops(void** ptr, int count)
    {
        Foo** p = (Foo**)ptr;
        for (int i = 0; i < count; i++)
        {
            Foo* f = p[i];
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(f->crop[j]);
            }
        }
    }
