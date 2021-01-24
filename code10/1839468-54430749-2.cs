    private static List<List<Point>> GetAllCombinations(int min, int max, int count)
    {
        var results = new List<List<Point>>();
        for (int i = 0; i < count; i++)
        {
            var thisSet = new List<Point>();
            for (int x = min; x <= max; x++)
            {
                for (int y = min; y <= max; y++)
                {
                    thisSet.Add(new Point(x, y));
                }
            }
            // If this is our first time through, we just add each point
            // as a single-item list to our results
            if (results.Count == 0)
            {
                foreach (var item in thisSet)
                {
                    results.Add(new List<Point> {item});
                }
            }
            // On subsequent iterations, for each list in our results, and
            // for each item in this set, we create a new list for each item,
            // adding to it a copy of the existing result list. We clear
            // the results in the beginning (after making a copy) and then
            // add each new list to it in the inner loop.
            else
            {
                // Make a copy of our existing results and clear the original list
                var tempResults = results.ToList();
                results.Clear();
                foreach (var existingItem in tempResults)
                {
                    foreach (var newPoint in thisSet)
                    {
                        // Now we populate our results again with a new set of 
                        // lists for each existingItem and each newPoint
                        var newItem = existingItem.ToList();
                        newItem.Add(newPoint);
                        results.Add(newItem);
                    }
                }
            }
        }
        return results;
    }
