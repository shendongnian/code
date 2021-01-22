    class A1 : II1
    {
        public void F()
        {
            // realizes II1.F()
        }
    }
    class A2 : II2
    {
        void II1.F()
        {
            // realizes II1.F()
        }
        void II2.F()
        {
            // realizes II2.F()
        }
    }
    class A3 : II2
    {
        public void F()
        {
            // realizes II1.F()
        }
        void II2.F()
        {
            // realizes II2.F()
        }
    }
If you have a reference to A2, you will not be able to call either version of F() without first casting to II1 or II2.
A2 a2 = new A2();
a2.F(); // invalid as both are explicitly implemented
((II1) a2).F(); // calls the II1 implementation
((II2) a2).F(); // calls the II2 implementation
If you have a reference to A3, you will be able to call the II1 version directly as it is an implicit implentation:
A3 a3 = new A3();
a3.F(); // calls the II1 implementation
((II2) a3).F(); // calls the II2 implementation
