    public class SomeType {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Number { get; set; }
    }
    public IQueryable<SomeType> ListProducts(string prodcutType)
    {
        var results = from p in db.Products
                      join s in db.Stocks
                      on p.ID equals s.IDProduct
                      where p.ptype == prodcutType
                      select new SomeType {
                          Width = s.width,
                          Height = s.height,
                          Number = s.number
                      };
        return results;
    }
