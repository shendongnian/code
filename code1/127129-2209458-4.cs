    using Bag = C5.TreeBag<C5.KeyValuePair<string, float>>;
    using Comparer = C5.DelegateComparer<C5.KeyValuePair<string, float>>;
    ...
    var bag = new Bag(new Comparer(
      (pair1, pair2) => 
        pair1.Value == pair2.Value ? 
        pair1.Key.CompareTo(pair2.Key) :
        // inverted because you need the highest entries 
        pair2.Value.CompareTo(pair1.Value))); 
    ...
    var topN = bag.Take(N).ToList();
