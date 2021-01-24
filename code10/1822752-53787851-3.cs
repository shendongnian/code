    ConcurrentDictionary<Vector2, Chunk> chunks = new ConcurrentDictionary<Vector2, Chunk>();
    List<Vector2> chunksToCreate = new List<Vector2>();
    public World(Chunk.ChunkGen generator, int program, int seed) {
        Program = program;
        Seed = seed;
        Parallel.ForEach(chunksToCreate, vec =>
            chunks.TryAdd(vec, generator(this, (int)vec.X, (int)vec.Y))
        );
    }
