    List<int> xs = new List<int> { 1, 2, 3, 4 };
    for (int i = 0; i < xs.Count; ++i)
    {
        // Remove even numbers.
        if (xs[i] % 2 == 0)
        {
            xs.RemoveAt(i);
            --i;
        }
    }
