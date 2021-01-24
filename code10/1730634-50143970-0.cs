    static void Main(string[] args)
    {
        List<List<double>> list = new List<List<double>>()
        {
            new List<double>() { 1,2,3 },
            new List<double>() { 4,5,6 },
            new List<double>() { 7,8,9 },
    
            new List<double>() { 2,3,1 },
            new List<double>() { 5,6,4 },
            new List<double>() { 8,9,7 },
    
            new List<double>() { 3,1,2 },
            new List<double>() { 6,4,5 },
            new List<double>() { 9,7,8 },
        };
    
        // Pick a method, they both work
        //var q2 = DictionaryMethod(list);
        var q2 = LinqAggregateMethod(list);
    
        foreach (var item in q2)
        {
            Console.WriteLine("List:");
            foreach (var item2 in item)
                Console.WriteLine($"\t{item2[0]}, {item2[1]}, {item2[2]}");
        }
    }
    
    static bool ListsAreEqual(List<double> x, List<double> y)
    {
        foreach (var d in x.Distinct())
        {
            if (x.Count(i => i == d) != y.Count(i => i == d))
                return false;
        }
        return true;
    }
    
    static IEnumerable<IEnumerable<List<double>>> LinqAggregateMethod(List<List<double>> list)
    {
        var q = list.Aggregate(new List<List<double>>() /* accumulator(ret) initial value */, (ret, dlist) =>
        {
            // ret = accumulator
            // dlist = one of the List<double> from list
    
            // If accumulator doesn't already contain dlist (or it's equal), add it
            if (!ret.Any(dlistRet => ListsAreEqual(dlist, dlistRet)))
                ret.Add(dlist);
            return ret;
        });
        // At this point, q contains one 'version' of each list.
    
        // foreach item in q, select all the items in list where the lists are equal
        var q2 = q.Select(dlist => list.Where(item => ListsAreEqual(dlist, item)));
        return q2;
    }
    
    static IEnumerable<IEnumerable<List<double>>> DictionaryMethod(List<List<double>> list)
    {
        var list2 = new Dictionary<List<double>, List<List<double>>>();
        // Loop over each List<double> in list
        foreach (var item in list)
        {
            // Does the dictionary have a key that is equal to this item?
            var key = list2.Keys.FirstOrDefault(k => ListsAreEqual(k, item));
            if (key == null)
            {
                // No key found, add it
                list2[item] = new List<List<double>>();
            }
            else
            {
                // Key was found, add item to its value
                list2[key].Add(item);
            }
        }
        var q2 = new List<List<List<double>>>();
        foreach (var key in list2.Keys)
        {
            var a = new List<List<double>>();
            a.Add(key); // Add the key
            a.AddRange(list2[key]); // Add the other lists
            q2.Add(a);
        }
        return q2;
    }
