    // class Program : IEqualityComparer<DateTime> // place something like this at the class definition.
    bool IEqualityComparer<DateTime>.Equals(DateTime x, DateTime y)
    {
        return x.Date == y.Date; // Compare the dates and not the times.
    }
    int IEqualityComparer<DateTime>.GetHashcode(DateTime obj)
    {
        return obj.Date.GetHashCode();
    }
