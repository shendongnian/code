    private static Dictionary<Key, SharedValue> relation = new Dictionary<Key, SharedValue>();
    static void Main(string[] args)
    {
        relation.Add(new Key{nameA="a",nameB="b"},new SharedValue{id=1});
        if(relation.ContainsKey(new Key{nameA="a",nameB="b"})){
            Console.WriteLine("YES");
        }
        if(relation.ContainsKey(new Key{nameA="b",nameB="a"})){
            Console.WriteLine("YES");
        }
        else Console.WriteLine("NO");
    }
