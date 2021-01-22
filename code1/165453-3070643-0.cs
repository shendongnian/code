    public class CartItem : ICartItem
    {
    
        #region ICartItem Members
    
        public int Quantity { get {...} set {...} }
    
        public bool IsDiscountable { get {...} set {...} }
    
        #endregion
    
        #region ISkuItem Members
    
        public string ISkuItem.SKU { get {...} set {...} }  //like this
        public string ICartItem.SKU { get {...} set {...} } //like this
    
        #endregion
    }
