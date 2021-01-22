    // Note that .NET favors Count over Length; all but traditional arrays use Count:
    for (var i = 0; i < immutable.Count; i++)
    {
        // this[] { get } is present, as ReadOnlyCollection<T> implements IList<T>:
        var element = immutable[i]; // Works
        // this[] { set } has to be present, as it is required by IList<T>, but it
        // will throw a NotSupportedException:
        immutable[i] = element; // Exception!
    }
    // ReadOnlyCollection<T> implements IEnumerable<T>, of course:
    foreach (var character in immutable)
    {
    }
    // LINQ works fine; idem
    var lowercase =
        from c in immutable
        where c >= 'a' && c <= 'z'
        select c;
    // You can always evaluate IEnumerable<T> implementations to arrays with LINQ:
    var mutableCopy = immutable.ToArray();
    // mutableCopy is: new[] { 'a', 'A', 'b', 'B', 'c', 'C' }
    var lowercaseArray = lowercase.ToArray();
    // lowercaseArray is: new[] { 'a', 'b', 'c' }
