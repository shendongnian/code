    private static IEnumerable<string> DescribeCSharp4(ClassA a)
    {
        var parent = a;
        var current = a.PropA;
        while (current != null)
        {
            yield return parent.Name + "     Class A with ID = " + current.ID;
            parent = current;
            current = current.PropA;
        }
    }
    ...
    var results = MyVar.SelectMany(DescribeCSharp4);
