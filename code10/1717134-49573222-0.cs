    public int Length { get; private set; }
    public void Enqueue(T item)
    {
      ++Length;
      // ...
    }
    public T Dequeue()
    {
      --Length;
      // ...
    }
