    public class DataBag : KeyedCollection<int, IDataHolder>
    {
        protected override int GetKeyForItem(IDataHolder item)
        {
            return item.Entity.ID;
        }
        public ICollection<int> Keys
        {
            get { return Dictionary.Keys; }
        }
    }
