    // bool[] isVisible = Enumerable.Repeat(true, 1000000).ToArray();
    bool[] isHidden = new bool[1000000]; // Crazy-fast initialization!
    // if (isVisible.All(v => v))
    if (isHidden.All(v => !v))
    {
        // Do stuff!
    }
