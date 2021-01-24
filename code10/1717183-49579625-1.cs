    public class ProductsRepository : IProductsRepository
    {
        private readonly WebApplication8.Data.ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteProduct(int id)
        {
            Product product = _context.Product.Find(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
        }
    }
