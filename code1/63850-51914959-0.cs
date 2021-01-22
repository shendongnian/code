    class A {
        protected:
        bool flag;
    };
    class B : public A {};
    class C : public A {};
    class D : public B, public C {
        public:
        void setFlag( bool nflag ){
    		flag = nflag; // ambiguous
        }
    };
