        class KeyEvent<T>
        {
            public T Args { get; set; }
            public Action<T> A { get; set; }
            public KeyEvent() { }
            public void ThrowEvent()
            {
                A.DynamicInvoke(Args);
            }
        }
 
        // ...
        static void M1(object[] o)
        {
            Console.WriteLine("M1 {0}", o);
        }
        static void M2(Vector2 v)
        {
            Console.WriteLine("M2 {0}", v);
        }
        static void Main(string[] args)
        {
            KeyEvent<object[]> e1 = new KeyEvent<object[]>
            { 
               A = new Action<object[]>(M1),
               Args = new object[] {};
            };
            KeyEvent<Vector2> e2 = new KeyEvent<Vector2>
            {
               A = new Action<Vector2>(M2),
               Args = new Vector2();
            };
        }
