    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    
    public abstract class Operator
    {
        public static readonly Operator Plus = new PlusOperator();
        public static readonly Operator Minus = 
             new GenericOperator((x, y) => x - y);
        public static readonly Operator Times = 
             new GenericOperator((x, y) => x * y);
        public static readonly Operator Divide = 
             new GenericOperator((x, y) => x / y);
        
        // Prevent other top-level types from instantiating
        private Operator()
        {
        }
        
        public abstract int Execute(int left, int right);
        
        private class PlusOperator : Operator
        {
            public override int Execute(int left, int right)
            {
                return left + right;
            }
        }
    
        private class GenericOperator : Operator
        {
            private readonly Func<int, int> op;
            
            internal GenericOperator(Func<int, int> op)
            {
                this.op = op;
            }
            
            public override int Execute(int left, int right)
            {
                return op(left + right);
            }
        }
    }
