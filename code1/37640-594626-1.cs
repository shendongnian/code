    public class TenPercentOffVoucher : IVoucher
    {
        public decimal CostOf(CartItem cartItem)
        {
            return cartItem.Cost * 0.9m;   
        }
    }
