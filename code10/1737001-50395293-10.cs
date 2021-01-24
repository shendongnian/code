    public static int KnapSackRecursive(Item[] items, int capacity)
    {
        // If there are no items or capacity is 0 then return 0
        if (items.Length == 0 || capacity == 0) return 0;
        // If there is one item and it fits then return it's value
        // otherwise return 0
        if (items.Length == 1)
        {
            return items[0].Weight < capacity ? items[0].Value : 0;
        }
        // keep track of the best value seen.
        int best = 0;
        for (int i = 0; i < items.Length; i++)
        {
            // This is an array of the other items.
            var otherItems = items.Take(i).Concat(items.Skip(i + 1)).ToArray();
            // Calculate the best value without using the current item.
            int without = KnapSackRecursive(otherItems, capacity);
            int with = 0;
            // If the current item fits then calculate the best value for
            // a capacity less it's weight and with it removed from contention
            // and add the current items value to that.
            if (items[i].Weight <= capacity)
            {
                with = KnapSackRecursive(otherItems, capacity - items[i].Weight) 
                    + items[i].Value;
            }
            
            // The current best is the max of the with or without.
            int currentBest = Math.Max(without, with);
            // determine if the current best is the overall best.
            if (currentBest > best)
                best = currentBest;
        }
        return best;
    }
