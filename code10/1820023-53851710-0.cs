    interface MyService
    {
        IList<Product> GetProducts();
        IList<Group<Product>> GetProductsGroupedByTaxability();
        IList<Group<Product>> GetProductsGroupedByManufacturer();
    }
    class Group<T>
    {
        public String Name { get; set; }
        public IList<T> Items { get; set; }
    }
