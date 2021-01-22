    public class ProductService
    {
        private readonly IItemRepository itemRepository;
        public ProductService (IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }
        public IEnumerable<Item> GetMaxItemSmth(Product product)
        {
            var max = this.itemRepository.GetMaxItemSmth(product);
            // Do something interesting here
            return max;
        }
    }
