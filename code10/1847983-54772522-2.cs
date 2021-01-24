    public class CreditCard : IPaymentMethod
    {
        public decimal Amount { get; set; }
        public decimal GetFee(IPaymentCalculationsVisitor visitor)
        {
            return visitor.CalculateFee(this);
        }
        public decimal GetExtraCharge(IPaymentCalculationsVisitor visitor)
        {
            return visitor.CalculateExtraCharge(this);
        }
    }
    
