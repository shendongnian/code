        static IEnumerable<int> Knapsack(IEnumerable<int> items, int goal)
        {
            var matches = from i in items
                          where i <= goal
                          let ia = new[] {i}
                          select i == goal ? ia : Knapsack(items, goal - i).Concat(ia);
            return matches.OrderBy(x => x.Count()).First();
        }
