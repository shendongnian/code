    public parital class Category 
    {
            public Ilist<Product> ProductsByPriceDate
            {
              get
              {
                  return this.Products.OrderbyDescending(p= > p.priceDate).ToList();
              }
            }
        }
