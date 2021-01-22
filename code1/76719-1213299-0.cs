    public abstract class Base
    {
        protected List<Items> getAllItems(String listName) 
        {
            // Implementation
        }
        public abstract List<Items> Items
        {
            get;
        }
    }
    public class NewClass : Base
    {
        public override List<Items> Items
        {
            get
            {
                return base.getAllItems("ListNameOfNewClass");
            }
        }
    }
