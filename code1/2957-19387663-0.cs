    public interface IMyDomainObjectDictionary 
    {
        IMyDomainObject GetMyDomainObject(string key);
    }
    internal class MyDomainObjectDictionary : IMyDomainObjectDictionary 
    {
        public IDictionary<string, IMyDomainObject> _myDictionary { get; set; }
        public IMyDomainObject GetMyDomainObject(string key)         {.._myDictionary .TryGetValue..etc...};
    }
