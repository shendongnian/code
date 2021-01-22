        public class BaseDAO
        {
            private const String CONNECTION_STRING = "Repository";
            private static BaseDAO dao = new BaseDAO();
            private SimpleRepository repository;
    
            protected BaseDAO()
            {
                if (repository == null)
                {
                    repository = new SimpleRepository(CONNECTION_STRING, SimpleRepositoryOptions.RunMigrations);
                }
            }
    
            public BaseDAO Instance()
            {
                return dao;
            }
    
            public SubSonic.Repository.SimpleRepository Repository
            {
                get { return this.repository; }
                set { this.repository = value; }
            }
        }
    public class ProductDAO : BaseDAO
    {
        public void save(ProductVO product)
        {
            if (product != null)
            {
                if (product.ID == null)
                {
                    product.ID = Guid.NewGuid();
                }
                this.Repository.Add<ProductVO>(product);
            }
            else
            {
                throw new ArgumentException("The product passed in was null!");
            }
        }
        public void update(ProductVO product)
        {
            if (product != null)
            {
                this.Repository.Update<ProductVO>(product);
            }
            else
            {
                throw new ArgumentException("The product passed in was null!");
            }
        }
        public List<ProductVO> fetchAll()
        {
            return fetchAll(null);
        }
        public List<ProductVO> fetchAll(String name)
        {
            IEnumerable<ProductVO> list = this.Repository.All<ProductVO>();
            if (name != null && name.Length > 0)
            {
                var output =
                    from products in list
                    where products.Name.ToLower().Contains(name.Trim().ToLower())
                    select products;
                list = output.ToList();
            }
            return list.OrderBy(product => product.Name).ToList();
        }
        public ProductVO fetchByID(object ID)
        {
            return this.Repository.Single<ProductVO>(ID);
        }
        public void delete(ProductVO product)
        {
            this.Repository.Delete<ProductVO>(product.ID);
        }
    }
