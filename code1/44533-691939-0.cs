    public DTOs.ProductCollection Get(int id, Func<Entities, XXX> selector)
    {
        using (Entities db = new Entities())
        {
            var result = (from collection in selector(db).Include("Product")
                        .Include("Product.Stuff1")
                        .Include("Product.Stuff2")
                       where collection.Id == id
                       select collection).FirstOrDefault();
            return ProductCollectionEFToProductCollectionDTO(result, true);
        }
    }
