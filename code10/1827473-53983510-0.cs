    public class DerivedModel : IBaseModel, IList<IBaseModel>
    {
        private int _size;
        private IBaseModel[] _items=new IBaseModel[1000];
        private int _version;
        public int Id { get; set; }
        public IEnumerator<IBaseModel> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    ...
    }
