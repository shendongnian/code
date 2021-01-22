        class KeyEvent<T>
        {
            public T Args { get; set; }
            public Action<T> a { get; set; }
            public KeyEvent(Action<T> a)
            {
                this.a = a;
            }
            public void ThrowEvent()
            {
                a.DynamicInvoke(Args);
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
            KeyEvent<object[]> e1 = new KeyEvent<object[]>(new Action<object[]>(M1));
            KeyEvent<Vector2> e2 = new KeyEvent<Vector2>(new Action<Vector2>(M2));
        }
