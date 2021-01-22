        public abstract class BaseClass {
            protected abstract IList<Item> getAllItems();
        }
        public class SubClass : BaseClass 
        {
            IItemsProvider itemsProvider;
            protected override IList<Item> getAllItems() 
            {
                return itemsProvider.getAllItems("filter");
            }
        }
        public interface IItemsProvider
        {
            IList<Item> getAllItems(string name);
        }
