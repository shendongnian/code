    public static void Main()
    {
      List<ICloneable> original = GetCloneableObjects();
      List<ICloneable> copies = new List<ICloneable>();
      Parallel.For(0, 100,
        i =>
        {
          ICloneable cloneable = original[i];
          ICloneable copy = cloneable.Clone();
          lock (copies)
          {
            copies.Add(copy);
          }
        });
    }
