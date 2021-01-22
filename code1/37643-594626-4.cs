    public class CartValueVisitor
    {
        private IVoucher voucher;
        public CartValueVisitor(IVoucher voucher)
        {
            this.voucher = voucher;
        }
        public decimal CostOf(Cart cart)
        {
            return cart.Items.Sum(item => voucher.CostOf(item));
        }
    }
