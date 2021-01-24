    public class D1 : BaseClass
    {
        private readonly DataHolder1 holder;
      
        public D1(DataHolder1 holder) { this.holder = holder; }
    
        public override BaseDataHolder Method1()
        {
            holder.localProp1.Dump();
            holder.localProp1 = "change1";
            return holder;
        }
    }
