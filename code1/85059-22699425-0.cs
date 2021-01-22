    public class ItemProcessor
    {
        private readonly IItemRepository _itemRepo;
        public ItemProcessor(IItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public Item GetMaxItemSmth(Product product)
        {
            // Here you are free to implement the logic as performant as possible, or as slowly
            // as you want.
            // Slow version
            //Item maxItem = _itemRepo.GetById(product.Items[0]);
            //for(int i = 1; i < product.Items.Length; i++)
            //{
            //    Item item = _itemRepo.GetById(product.Items[i]);
            //    if(item > maxItem) maxItem = item;
            //}
            //Fast version
            Item maxItem = _itemRepo.GetMaxItemSmth();
            return maxItem;
        }
    }
