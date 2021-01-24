    ResultOfStrategy[] ros2;
    using (var container = new ResultOfStrategyContainer())
    {
        MyCppFunc2(container.CreateArray);
        ros2 = container.ResultOfStrategy;
        // Don't do anything inside of here! We have a
        // pinned object here, the .NET GC doesn't like
        // to have pinned objects around!
        Console.Write("Case 2: ");
        CheckIfMarshaled(ros2);
    }
    // Do the work with ros2 here!
