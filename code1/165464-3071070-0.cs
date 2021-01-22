    class CartItem : ICartItem
    {
        public int Quantity { get; set; }
        public bool IsDiscountable { get; set; }
        string ISkuItem.SKU
        {
            get { return "ISkuItem"; }
            set { throw new NotSupportedException(); }
        }
        string ICartItem.SKU
        {
            get { return "ICartItem"; }
            set { throw new NotSupportedException(); }
        }
    }
