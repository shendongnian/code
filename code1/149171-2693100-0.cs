    class Foo
    {
        public Foo(int weight) { Weight = weight; }
        public int Weight { get; set; }
    }
...
    IEnumerable<IList<Foo>> GroupFoosByWeight(IList<Foo> foos, int weightLimit)
    {
        List<Foo> list = new List<Foo>();
        int sumOfWeight = 0;
    
        foreach (Foo foo in foos)
        {
            if (sumOfWeight + foo.Weight > weightLimit)
            {
                yield return list;
                sumOfWeight = 0;
                list.Clear();
            }
    
            list.Add(foo);
            sumOfWeight += foo.Weight;
        }
    
        if (list.Count > 0)
            yield return list;
    }
