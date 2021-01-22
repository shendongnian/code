       private int _id;
       private List<ItemDetails> _detailItems = new List<ItemDetails>();
       public Item(int id)<br>
       {
           _id = id;
       }
       public void AddItemDetail(ItemDetails itemDetail)
       {
           _detailItems.Add(itemDetail);
       }
 
       public int Id
       {
           get { return _id; }
       }
       public ReadOnlyCollection<ItemDetails> DetailItems
       {
           get { return _detailItems.AsReadOnly(); }
       }
    }
    public class ItemDetails
    {
        private int _parentId;
        public ItemDetails(int parentId)
        {
            _parentId = parentId;
        }
        public int ParentId
        {
            get { return _parentId; }
        }
    }
