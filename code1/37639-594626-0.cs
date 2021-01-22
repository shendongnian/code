    public class FullPriceVoucher : IVoucher
    {
        public decimal CostOf(CartItem cartItem)
        {
            return cartItem.Cost;   
        }
    }
