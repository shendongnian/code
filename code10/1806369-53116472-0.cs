    public class D1 : BaseClass
    {
        public DataHolder1 Holder {get; set;}
    
        public override BaseDataHolder Method1()
        {
            Holder.localProp1.Dump();
            Holder.localProp1 = "change1";
            return holder;
        }
    }
