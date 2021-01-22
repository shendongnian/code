    public interface ICommonDalObject
    {
        public string LuceneQueryString { get; }
        public ITranslation GetTranslation();
    }
