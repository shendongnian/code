    IDictionary<int, MyObject> dict = new Dictionary<int, MyObject>();
    // ... Populate dict with data.
    IList<int> keyList = new List<int>();
    keyList.AddRange(dict.Keys);
    // Sort keyList based on key's value.
    // MyObject must implement IComparable<MyObject>.
    keyList.Sort(delegate(int x, int y) {
       return dict[x].CompareTo(dict[y]);
    });
    foreach (int key in keyList) {
       MyObject value = dict[key];
    }
