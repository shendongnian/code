    class StudentComparer : IComparer<FetchedStudent>
    {
        private readonly IComparer<int> UserIdComparer = Comparer<int>.Default;
        private readonly IComparer<DateTime> nextFollowUpdateComparer =
                         Comparer<DateTime>.Default;
        public int CompareTo(FetchedStudent x, FetchedStudent y)
        {
            // TODO: decide what to do with null students: exception?
            // or return as smallest or largest
            // Case 1: x in sorting group 1
            if (x.Message == null && x.Status == notActive)
            {
                // x is in sorting group 1
                if (y.Message == null && y.Status == notActive)
                {
                    // x and y are in sorting group 1.
                    // order by descending UserId
                    return -UserIdComparer.CompareTo(x.UserId, y.UserId);
                    // the minus sign is because of the descending
                }
                else
                {   // x is in group 1, y in group 2 / 3 / 4: x comes first
                    return -1;
                }
            }
            // case 2: X in group 2
            else if (x.Message != null && x.Status != notActive)
            {   // x is in group 2
                if (y.Message == null && y.Status != notActive)
                {   // x is in group 2; y is in group 1: x is larger than y
                    return +1;
                }
                else if (y.Message == null && y.Status != notActive)
                {   // x and y both in group 2: order by descending nextFollowUpDate
                    // minus sign is because descending
                    return -nextFollowUpdateComparer.CompareTo(
                           x.Message.NextFollowUpdate,
                           y.Message.NextFollowUpdate);
                }
                else
                {   // x in group 2, y in 3 or 4: x comes first
                    return -1;
                }
            }
          
            // case 3: X in group 3
            else if (x.Message == null && x.Status != notActive)
            {
               ... etc, you'll know the drill by know
        }
    }    
