    using System.Dynamic.DynamicObject
    class A : DynamicObject 
    {
        private int val;
        A(int myvalue)
        {
            this.val = myvalue;
        }
        
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result) {
            result = this.val;
            return true;
        }
    }
    
    ...
    dynamic a = new A(5);
    Console.Write(a());
