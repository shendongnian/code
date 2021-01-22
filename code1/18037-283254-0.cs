    public void GetData(Dictionary<T,V> dataDictionary) // or IDictionary<T,V>
    {
        T key = GetSomeKey();
        V value = dataDictionary[key]; // query
        dataDictionary.Remove(key); // mutate
    }
