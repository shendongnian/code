    // Make a list of integers.
    List<int> list = new List<int>();
    list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
    // Call FindAll() using traditional delegate syntax.
    Predicate<int> callback = new Predicate<int>(IsEvenNumber);
    List<int> evenNumbers = list.FindAll(callback);
    
    // Target for the Predicate<> delegate.
    static bool IsEvenNumber(int i)
    {
        // Is it an even number?
        return (i % 2) == 0;
    }
