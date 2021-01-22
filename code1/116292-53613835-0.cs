    /// <summary>Removes all keys and values from the <see cref="T:System.Collections.Generic.Dictionary`2" />.</summary>
    [__DynamicallyInvokable]
    public void Clear()
    {
      if (this.count <= 0)
        return;
      for (int index = 0; index < this.buckets.Length; ++index)
        this.buckets[index] = -1;
      Array.Clear((Array) this.entries, 0, this.count);
      this.freeList = -1;
      this.count = 0;
      this.freeCount = 0;
      ++this.version;
    }
