        internal abstract class AbstractClass
        {
            //Properties for parameterization from concrete class
            protected abstract string Param1 { get; }
            protected abstract string Param2 { get; }
            //Internal fields need for manage state of object
            private string var1;
            private string var2;
            internal AbstractClass(string _var1, string _var2)
            {
                this.var1 = _var1;
                this.var2 = _var2;
            }
            internal void CalcResult()
            {
                //The result calculation uses Param1, Param2, var1, var2;
            }
        }
        internal class ConcreteClassFirst : AbstractClass
        {
            private string param1;
            private string param2;
            protected override string Param1 { get { return param1; } }
            protected override string Param2 { get { return param2; } }
            public ConcreteClassFirst(string _var1, string _var2) : base(_var1, _var2) { }
            internal void CalcParams()
            {
                //The calculation param1 and param2
            }
        }
        internal class ConcreteClassSecond : AbstractClass
        {
            private string param1;
            private string param2;
            protected override string Param1 { get { return param1; } }
            protected override string Param2 { get { return param2; } }
            public ConcreteClassSecond(string _var1, string _var2) : base(_var1, _var2) { }
            internal void CalcParams()
            {
                //The calculation param1 and param2
            }
        }
        static void Main(string[] args)
        {
            string var1_1 = "val1_1";
            string var1_2 = "val1_2";
            ConcreteClassFirst concreteClassFirst = new ConcreteClassFirst(var1_1, var1_2);
            concreteClassFirst.CalcParams();
            concreteClassFirst.CalcResult();
            string var2_1 = "val2_1";
            string var2_2 = "val2_2";
            ConcreteClassSecond concreteClassSecond = new ConcreteClassSecond(var2_1, var2_2);
            concreteClassSecond.CalcParams();
            concreteClassSecond.CalcResult();
            //Param1 and Param2 are not visible in main method
        }
