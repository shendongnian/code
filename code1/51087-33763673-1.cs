    public abstract class ModelBase : IIdentifiable
    {
        object IIdentifiable.Id
        {
            get { return GetId();  }
        }
        protected abstract object GetId();
    }
    public class Product : ModelBase, IIdentifiable<int>
    {
        public int ProductID { get; set; }
        public int Id
        {
            get { return ProductID; }
        }
        protected override object GetId()
        {
            return Id;
        }
    }
