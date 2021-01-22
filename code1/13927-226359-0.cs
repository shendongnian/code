        // A list of actions to execute later
        List<Action> actions = new List<Action>();
        // Numbers 0 to 9
        List<int> numbers = Enumerable.Range(0, 10).ToList();
        // Store an action that prints each number (WRONG!)
        foreach (int number in numbers)
            actions.Add(() => Console.WriteLine(number));
        // Run the actions, we actually print 10 copies of "9"
        foreach (Action action in actions)
            action();
        // So try again
        actions.Clear();
        // Store an action that prints each number (RIGHT!)
        numbers.ForEach(number =>
            actions.Add(() => Console.WriteLine(number)));
        // Run the actions
        foreach (Action action in actions)
            action();
