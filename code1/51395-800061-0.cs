    public int CompareTo(Element other)
    {
        var ret = Priority.CompareTo(other.Priority);
        if (ret == 0)
        {
            ret = Comparer<int>.Default.Compare(Index, other.Index);
        }
        return ret;
    }
