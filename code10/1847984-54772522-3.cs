    public class CreditCard : IPaymentMethod
    {
        // Following OOP principles and keep data private
        private decimal _amount;
        public CreditCard(decimal amount) => _amount;
        public decimal GetFee(IPaymentCalculationsVisitor visitor)
        {
            return visitor.CalculateFee(_amount); // provide only required data
        }
        public decimal GetExtraCharge(IPaymentCalculationsVisitor visitor)
        {
            return visitor.CalculateExtraCharge(_amount); // provide only required data
        }
    }
