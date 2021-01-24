    public int GetNext(List<int> list)
    {
       var max = list.Any() ? list.Max() : 0;
       return max >= 127 ? Enumerable.Range(1, 127).Except(list).First() : max+1;
    }
