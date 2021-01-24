    public class Die
    {
        private static Random Random = new Random(); // random is static to avoid repeats
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
            Value = Random.Next(1, FaceCount);
            return Value;
        }
    }
