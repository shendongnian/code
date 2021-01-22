    public class ProtocolHelper
    {
        public void Same1() {}
        public void Same2() {}
    }
    public class Protocol1 : IProtocol
    {
        private readonly ProtocolHelper _helper = new ProtocolHelper();
        void MyInterfaceMethod1()
        {
            _helper.Same1();
            DiffStuff();
            _helper.Same2();
        }
    }
