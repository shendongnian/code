     public class BusinessServiceN : ServiceBase, IBusinessServiceN
    {
        public BusinessServiceN(IBusinessContext context)
               : base(context) { }
        public override void DoSomethingAfter()
        {
            //Your custom implementation here
        }
    }
