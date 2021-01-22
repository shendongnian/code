    // initialize a list of integers. Enumerable.Range returns 0-9,
    // which is passed to the overloaded List constructor that accepts
    // an IEnumerable<T>
    var list = new List<int>(Enumerable.Range(0, 10));
    // initialize an expression lambda that returns 2
    Func<int> x = () => 2;
    // using the List.ForEach method, iterate over the integers to write something
    // to the console.
    // Execute the expression lambda by calling x() (which returns 2)
    // and multiply the result by the current integer
    list.ForEach(i => Console.WriteLine(x() * i));
    // Result: 0,2,4,6,8,10,12,14,16,18
