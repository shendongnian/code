    class C
    {
        int x;
        void M()
        {
            Console.WriteLine(x); // this.x
            {
                int x;
            }
        }
    }
