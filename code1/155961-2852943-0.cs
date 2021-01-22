    private void UpdatePosition(TItem item)
    {
        // each bucket holds some MxN section of the X,Y grid
        var nextBucket = CalculateBucket(item.Position);
        if (nextBucket != item.Bucket)
        {
            lock (wholeCollectionLock)
            {
                this.buckets[nextBucket].Add(item);
                this.buckets[item.Bucket].Remove(item);
                item.Bucket = nextBucket;
            }
        }
    }
    public IEnumerable<TItem> ItemsAt(TPosition position)
    {
        var bucket = CalculateBucket(position);
        lock (wholeCollectionLock)
        {
            // this will be efficient enough for cases where O(n) searches
            // have small enough n's
            // needs to be .ToArray for "snapshot"
            return this.buckets[bucket].Where(xx => xx.Position == position).ToArray();
        }
    }
