    using Bag = C5.TreeBag<C5.KeyValuePair<string, float>>;
    using Comparer = C5.DelegateComparer<C5.KeyValuePair<string, float>>;
    ...
    var bag = new Bag(new Comparer(
      (pair1, pair2) => pair2.Value.CompareTo(pair1.Value))); // inverted because you need the highest entries
    ...
    var topN = bag.Take(N).ToList();
