    public abstract class Base
    {
        protected abstract string ListName { get; }
        public List<Item> GetItems()
        {
            return Web.GetList(ListName);
        }
    }
    public class Child : Base
    {
        protected override string ListName
        {
            get { return "MyListName"; }
        }
    }
