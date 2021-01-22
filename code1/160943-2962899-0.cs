    class Program
    {
        static void Main(string[] args)
        {
            var paramList = new List<IParameter>();
            paramList.Add(new FooParameter());
            paramList.Add(new BarParameter());
            paramList.Add(new F1());
            paramList.Add(new F2());
    
            foreach (var p in paramList)
            {
                p.DoCommonOperation();
                DoSpecificOperation(p);
            }
    
            Console.ReadKey();
        }
    
        private static void DoSpecificOperation(IParameter p)
        {
            if (p is F1)
            {
                (p as F1).F1Method();
            }
            else if (p is F2)
            {
                (p as F2).F2Method();
            }
    
        }
    
        interface IParameter 
        {
            void DoCommonOperation();
        }
    
        abstract class ParamBase : IParameter
        {
            public virtual void DoCommonOperation()
            {
                Console.WriteLine("ParamBase");
            }
        }
    
        class FooParameter : ParamBase
        {
            public override void DoCommonOperation()
            {
                Console.WriteLine("FooParameter");
            }
        }
    
        class BarParameter : ParamBase
        {
            public override void DoCommonOperation()
            {
                Console.WriteLine("BarParameter");
            }
        }
    
        class F1 : FooParameter
        {
            public override void DoCommonOperation()
            {
                Console.WriteLine("F1");
            }
    
            public void F1Method()
            {
                Console.WriteLine("F1.F1Method");
            }
        }
    
        class F2 : FooParameter
        {
            public override void DoCommonOperation()
            {
                Console.WriteLine("F2");
            }
    
            public void F2Method()
            {
                Console.WriteLine("F2.F2Method");
            }
        }
    }
