    unsafe class Test
    {
        static public void Test1(int p, out int id)
        {
            int* i = (int*)(p);
            id = *i;
            i++;
        }
        static public void Test2(int p, out int id)
        {
            int* i = (int*)(p);
            id = *i++;
        }
    }
