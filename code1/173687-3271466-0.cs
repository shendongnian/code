    private static readonly int numLocks = 16;
    private object[] locks = (from i in Range(0, numLocks) select new object()).ToArray();
    private Tile[] tiles = hugeTileArray();
    ...
    public Tile this[int i] {
    {
        set
        {
            lock (locks[i % numLocks])
            {
                tiles[i] = value;
            }
        }
    }
