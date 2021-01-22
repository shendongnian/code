    public struct Difficaulty
    {
        Easy,
        Medium,
        Hard
    }
    public struct Level
    {
        const Difficaulty DefaultLevel = Difficaulty.Medium;
        private Difficaulty _level; // this field must not be modified other than with its property.
        public Difficaulty Difficaulty
        {
            get => _level + DefaultLevel;
            set => _level = value - DefaultLevel;
        }
    }
