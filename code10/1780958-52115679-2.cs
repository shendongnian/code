    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public override Product FindById(int id)
        {
            // find
        }
        public override void Create(Product product)
        {
            // save 
        }
        public void SomeProductRepoMethod(int someParam)
        {
            // do product repository specific stuff
        }
        public override void Delete(Product entity)
        {
            // delete
        }
    }
