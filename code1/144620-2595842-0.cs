     public ref class MyWrapper
        {
        public:
        MyWrapper (void)
        {
        pObj = new CMyUnmanagedClass();
        }
        ~MyWrapper (void)
        {
        delete pObj;
        }
        int foo(void)
        {
        //pass through to the unmanaged object
        return pObj->foo();
        }
        private:
        CMyUnmanagedClass* pObj;
        };
