    class ShoppingCart
    {
        public IList<CartLine> Items { get; } = new List<CartLine>();
    
        public ShoppingCart() {}
    }
    
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    
    @model ShoppingCart
    @foreach (var item in Model.Items)
    {
       <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Product)
            </td>
