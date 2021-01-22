    class ThirdPartyBaseClass1
    {
        public void DoOne() {}
    }
    class ThirdPartyBaseClass2
    {
        public void DoTwo() { }
    }
    class ThirdPartyBaseClass3
    {
        public void DoThree() { }
    }
    abstract class Base
    {
        public void DoAll() { }
    }
    class Class1 : Base
    {
        public void DoOne() { _doer.DoOne(); }
        private readonly ThirdPartyBaseClass1 _doer = new ThirdPartyBaseClass1();
    }
    class Class2 : Base
    {
        public void DoTwo() { _doer.DoTwo(); }
        private readonly ThirdPartyBaseClass2 _doer = new ThirdPartyBaseClass2();
    }
    class Class3 : Base
    {
        public void DoThree() { _doer.DoThree(); }
        private readonly ThirdPartyBaseClass3 _doer = new ThirdPartyBaseClass3();
    }
