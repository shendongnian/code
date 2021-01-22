    X<int> x = new X<int>();
    var e1 = x.GetEnumerator(); // invokes IEnumerable<int>.GetEnumerator
                               // IEnumerable.GetEnumerator is not visible
    IEnumerable y = x;
    var e2 = y.GetEnumerator(); // invokes IEnumerable.GetEnumerator
