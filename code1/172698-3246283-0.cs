       struct S
        {
            public int x;
            static S()
            {
                Console.WriteLine("static S()");
            }
            public void f() { }
        }
    
        static void Main() { new S().f(); }
