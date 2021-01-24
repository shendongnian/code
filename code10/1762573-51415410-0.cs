    var deleteList = ExistingItems.Except(NewItemList, new ItemComparer()).ToList();
    var addList = NewItemList.Except(ExistingItems, new ItemComparer()).ToList();
    class Item
    {
        public int ID { get; set; }
        public int Price { get; set; }
    }
    class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.ID == y.ID;
        }
        public int GetHashCode(Item obj)
        {
            return obj.GetHashCode();
        }
    }
