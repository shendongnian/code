    public interface IFactory<T>
    {
        T Create();
    }
    [Serializable]
    public class ExampleItemFactory : IFactory<T>
    {
        public int Param1 { get; set; }
        public string Param2 { get; set; }
        #region IFactory<T> Members
        public Item Create()
        {
            return new Item(this.Param1, this.Param2);
        }
        #endregion
    }
    public class CreateCommand<T> : Command
    {
        public T Item;
        protected IFactory<T> _ItemFactory;
        public CreateCommand(IFactory<T> factory)
        {
            _ItemFactory = factory;
        }
        public override void Execute()
        {
            Item = _ItemFactory.Create();
        }
    }
