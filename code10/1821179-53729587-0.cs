    public class NPC : IEquatable<NPC>
    {
        private static int _indexKeeper = 0;
        public int Index { get; } = _indexKeeper++;
        public bool Equals(NPC other)
        {
            return Index == other?.Index;
        }
        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }
    }
