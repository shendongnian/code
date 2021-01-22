    public struct Tempo
    {
        const double DefaultBpm = 120;
        private double _bpm; // this field must not be modified other than with its property.
        public double BeatsPerMinute
        {
            get => _bpm + DefaultBpm;
            set => _bpm = value - DefaultBpm;
        }
    }
