    public abstract class AbstractObject {
        protected string id;
        public string Id
        {
            get { return id; }
        }
    }
    
    public class ConcreteObject : AbstractObject
    {
        public new string Id
        {
            get { return base.Id; }
            set { id = value; }
        }
    }
