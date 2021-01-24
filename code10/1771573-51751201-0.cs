    interface InterfaceIn {
        string p1 {get;set;}
        void m1();
    }
    interface InterfaceOut {
         string p2 {get;set;}
         void m2();
    }
    class ConcreteIn : InterfaceIn {
        public string p1 {get;set;}
        public void m1() {}
    }
    class ConcreteOut1 : InterfaceOut {
        public string p2 {get;set;}
        public void m2() {}
    }
    class ConcreteOut2 : InterfaceOut {
        public string p2 {get;set;}
        public void m2() {}
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ConcreteIn{p1 = "some value"};
            var b = mapIt<ConcreteIn, ConcreteOut1>(a);
            var c = mapIt<ConcreteIn, ConcreteOut2>(a);
        }
        public static V mapIt<U, V>(U val) where U: InterfaceIn where V: InterfaceOut, new() {
            var res = new V {p2 = val.p1};
            return res;
        }
    }
