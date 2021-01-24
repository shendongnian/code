    public int GetNext(List<int> list)
    {
         if(list == null) throw new ArgumentNullException(nameof(list));
         var max = list.Count > 0 ? list.Max() : 0;
         return max >= 127 ? Enumerable.Range(1, 127).Except(list).First() : max + 1;
    }
