    // Note: You may well want to make this a struct instead.
    public sealed class RotationRange
    {
        public float Start { get; }
        public float End { get; }
        public float Range => End - Start;
        private RotationRange(float start, float end)
        {
            Start = start;
            End = end;
        }
        public bool IsValid(float angle) => angle <= Start && angle < End;
        public static RotationRange FromStartAndEnd(float start, float end) =>
            new Rotation(start, end);
        public static RotationRange FromStartAndRange(float start, float range) =>
            new Rotation(start, start + range);
    }
