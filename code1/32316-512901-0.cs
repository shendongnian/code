    class Program
    {
        static void Main(string[] args)
        {
            IAddBaseItem addItem = new DerivedList();
            BaseItem item = new DerivedItem();
            IgnorantMethod(addItem, item);
        }
        static void IgnorantMethod(IAddBaseItem list, BaseItem item)
        {
            list.Add(item);
        }
    }
    class BaseItem
    {
    }
    class BaseList<T> : List<T>, IAddBaseItem
    {
        #region IAddBaseItem Members
        void IAddBaseItem.Add(BaseItem item)
        {
            if (item == null)
                Add(item);
            else
            {
                T typedItem = item as T;
                // If the 'as' operation fails the item isn't
                // of type T.
                if (typedItem == null)
                    throw new ArgumentOutOfRangeException("T", "Wrong type");
                Add(typedItem);
            }
        }
        #endregion
    }
    class DerivedList : BaseList<DerivedItem>
    {
    }
    class DerivedItem : BaseItem
    {
    }
    interface IAddBaseItem
    {
        void Add(BaseItem item);
    }
