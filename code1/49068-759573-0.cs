    static void Write(object obj) {
        if (obj == null) { }
        else if (obj is IDictionary) { Write((IDictionary)obj); }
        else if (obj is IList) { Write((IList)obj); }
        else { Console.WriteLine(obj); }
    }
    static void Write(IList data) {
        foreach (object obj in data) {
            Console.WriteLine(obj);
        }
    }
    static void Write(IDictionary data) {
        foreach (DictionaryEntry entry in data) {
            Console.WriteLine(entry.Key + "=" + entry.Value);
        }
    }
