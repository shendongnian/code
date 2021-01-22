    class ItemBase{}
    class ItemA : ItemBase{}
    class ItemB : ItemBase{}
    class BaseClass
    {
        public virtual void Add(ItemBase item){}
        public virtual ItemBase CreateItem() { return null; }
    }
    class ClassA : BaseClass
    {
        public override void Add(ItemBase item)
        {
            //do whatever
            throw new NotImplementedException();
        }
        public ItemBase CreateItem()
        {
            //create an ItemBase and return
            throw new NotImplementedException();
        }
    }
