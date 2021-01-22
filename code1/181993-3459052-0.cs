    interface IFoo { void A(); }
    interface IBar { void B(); }
    
    class Test<T> where T Ifoo <OR> IBar
    {
        void M() {  T.A(); } // will this work?? 
    }
