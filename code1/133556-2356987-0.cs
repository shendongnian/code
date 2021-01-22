    public interface IBillTypePolicy
    {
        public BillType { get; }
        void HandleBillType();
    }
    public class BillPolicy : IBillTypePolicy
    {
        public BillType BillType { get { return BillType.Bill; } }
        public void HandleBillType() 
        { 
            // your code here...
        }
    }
