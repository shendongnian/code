    namespace Option3
    {
        public AuxClass
        {
            public string Field1 { get; set; }
            public Method1() { ... }
            public Method1() { ... }
        }
        public MainClass
        {
            public AuxClass Aux { get; private set; }
            public MainClass(AuxClass aux)
            {
                this.Aux = aux;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Option3.AuxClass = auxClass3 = new Option3.AuxClass();
            Option3.MainClass mainClass3 = new Option3.MainClass(auxClass3);
            mainClass3.Aux.Field1 = "string2";
            mainClass3.Aux.Method1();
            mainClass3.Aux.Method2();
        }
    }
