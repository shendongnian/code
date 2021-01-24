    public class Foo
    {
        #if ClientA
        public void S() { }
        #endif
        #if !ClientC
        public void D() { }
        #endIf
        #if !ClientB
        public void M() { }
        #endif
    }
