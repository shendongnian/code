    private Result GetMax(ICollection<int> items, int itemCount)
    {
      return items.
        Take(items.Count - (itemCount - 1)).
        Select((value, index) => items.Skip(index).Take(itemCount)).
        Select((group, index) =>
          new Result
          {
            Index = index,
            Sum = group.Aggregate(0, (sum, i) => sum + (i == 0 ? int.MinValue : i))
          }).
        Max();
    }
    
    private struct Result : IComparable<Result>
    {
      public int Index { get; set; }
      public int Sum { get; set; }
    
      public int CompareTo(Result other)
      {
        return Sum.CompareTo(other.Sum);
      }
    }
