    class Test
    {
        static void Main()
        {
            int i = 10;
            PassByRef(ref i);
            // Now i is 20
            PassByValue(i);
            // i is *still* 20
        }
        static void PassByRef(ref int x)
        {
            x = 20;
        }
        static void PassByValue(int x)
        {
            x = 50;
        }
    }
   
