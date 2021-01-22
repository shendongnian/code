    using System.Linq.Enumerable;
    ...
    List<KeyValuePair<string, string>> myList = aDictionary.ToList();
    myList.Sort(
        delegate(KeyValuePair<string, string> pair1,
        KeyValuePair<string, string> pair2)
        {
            return pair1.Value.CompareTo(pair2.Value);
        }
    );
