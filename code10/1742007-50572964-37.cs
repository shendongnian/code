    ResultOfStrategy[] ros;
    using (var pa = new PinnedArray<ResultOfStrategy>())
    {
        MyCppFunc2(pa.CreateArray);
        ros = pa.Array;
        // Don't do anything inside of here! We have a
        // pinned object here, the .NET GC doesn't like
        // to have pinned objects around!
        Console.Write("Case 2: ");
        CheckIfMarshaled(ros);
    }
    // Do the work with ros here!
