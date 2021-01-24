    public class CreditCard : IPaymentMethod
    {
        public decimal Amount { get; set; }
        public decimal GetFee(IPaymentCalculationsVisitor visitor)
        {
            return visitor.CalculateFee(Amount); // provide only required data
        }
        public decimal GetExtraCharge(IPaymentCalculationsVisitor visitor)
        {
            return visitor.CalculateExtraCharge(Amount); // provide only required data
        }
    }
