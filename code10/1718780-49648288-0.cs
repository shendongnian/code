    var result = tasks.Aggregate(new List<Item>(), (acc, current) =>
    {
        if (acc.Count > 0)
        {
            var prev = acc[acc.Count - 1];
            if (prev.Action == current.Action && prev.Target == current.Source)
            {
                // update previous target
                prev.Target = current.Target;
            }
            // otherwise just add
            else acc.Add(current);
        }
        else acc.Add(current);
        return acc;
    });
