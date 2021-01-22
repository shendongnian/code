    var list = new List<int> { 1, 2, 3, 4, 5 };
    using (var enumerator = list.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            var element = enumerator.Current;
        }
    }
