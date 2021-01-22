    public class MyDictionary : Dictionary<string, IFoo>, IMyDictionary
    {
        ICollection<string> IMyDictionary.Keys
        {
            get { return Keys; }
        }
        IEnumerable<IFoo> IMyDictionary.Values
        {
            get { return Values; }
        }
    }
