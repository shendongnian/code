    public partial class Order
    {
            public IList<Product> Products
            {
                get
                {
                    var list = new List<Product>();
                    foreach (var item in this.Order_Details)
                    {
                        list.Add(item.Product);
                    }
                    return list;
                }
            }
     }
