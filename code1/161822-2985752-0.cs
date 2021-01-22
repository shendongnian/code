    unsafe class Bar {
        private int* m_ref;
        public Bar(int* val) {
            m_ref = val;
        }
        public void AddOne() {
            *m_ref += 1;
        }
    }
    unsafe class Program {
        static void Main() {
            int foo = 7;
            Bar b = new Bar(&foo);
            b.AddOne();
            Console.WriteLine(foo);    // prints 8
            Console.ReadLine();
        }
    }
