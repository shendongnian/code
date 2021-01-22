    public class DiscountEngine
    {
        public Cart As Cart { get; set;}
        public Discount As Discount { get; set;}
        private class SKUGroup
        {
            public int ItemDiscountsApplied = 0
            public int TotalDiscounts = 0
            public int ID = 0
        }
        public void ApplySKUGroupDiscountToCart()
        {
            ...
        }
        private void ApplyDiscountToSingleCartItem(ref CartItem cartI, 
                                                   ref DiscountItem discountI)
        {
            ...
        }
    }
