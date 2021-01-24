    .Select(student => new FetchedStudent
    {
        SortingGroup = student.ToSortingGroup(),
 
        ... // other properties you need
    }
    public int CompareTo(FetchedStudent x, FetchedStudent y)
    {
        switch (x.SortingGroup)
        {
            case 1:
               switch y.SortingGroup:
               {
                   case 1: // x and y both in sorting group 1
                      return -UserIdComparer.CompareTo(x.UserId, y.UserId);
                   default: // x in sorting group 1, y in 2 / 3 / 4: x smaller
                      return -1;
               }
            case 2:
               switch y.SortingGroup:
               {
                   case 1: // x in sorting group 2; y in sorting group 1: x larger
                      return +1;
                   case 2: // x and y both in sorting group 2
                      return -nextFollowUpdateComparer.CompareTo(
                           x.Message.NextFollowUpdate,
                           y.Message.NextFollowUpdate);
               }    
