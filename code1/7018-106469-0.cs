    interface I
    {
        void C();
    }
    class BaseClass
    {
        public void A() { MessageBox.Show("A"); }
        public void B() { MessageBox.Show("B"); }
    }
    class Derived : I
    {
        public void C()
        {
            b.A();
            b.B();
        }
        private BaseClass b;
    }
