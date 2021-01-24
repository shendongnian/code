    private static SortBucket GetBucket(Item item, int position, int recentItemCount)
    {
      if (position <= recentItemCount)
      {
        return SortBucket.RecentItems;
      }
      return item.IsPriority ? SortBucket.PriorityItems : SortBucket.Rest;
    }
