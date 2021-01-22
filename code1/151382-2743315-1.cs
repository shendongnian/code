    public interface IBaseClass
    {
        int ID { get; set; }
    }
    
    internal class MyBaseClass : IBaseClass
    {
        public MyBaseClass() { }
        public int IBaseClass.ID { get; set; }
    }
    
    public class MyExposedClass : IBaseClass
    {
        private MyBaseClass _base = new MyBaseClass();
    
        public int IBaseClass.ID
        {
            get { return _base.ID; }
            set { _base.ID = value; }
        }
    }
