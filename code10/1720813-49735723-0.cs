        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if (entry.Entity is #insert type of your object#)
            {
                entry.Entity.Estimated = (BestCase + 4 * MostLikely + WorstCase) / 6;
            }
        }
