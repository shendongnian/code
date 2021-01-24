    public interface IDataDictionary<T> where T : IDataDictionaryItem
    {
        List<T> DictionaryItems { get; set; }
    }
    public class HairColorDictionary : IDataDictionary<HairColor>
    {
        public List<HairColor> DictionaryItems { get; set; }
    }
