    public class Die
    {
        static int seed = Environment.TickCount;
        static readonly ThreadLocal<Random> DieRandom = new ThreadLocal<Random>(() 
            => new Random(Interlocked.Increment(ref seed)));
        public int FaceCount { get; }
        public int Value { get; private set; }
        public Die() : this(6) // default to 6 faces
        {
        }
        public Die(int faceCount)
        {
            if (faceCount < 3) // validate input
                throw new ArgumentOutOfRangeException(nameof(faceCount));
            this.FaceCount = faceCount;
        }
        public int Roll()
        {
            Value = DieRandom.Next(1, FaceCount + 1);
            return Value;
        }
    }
