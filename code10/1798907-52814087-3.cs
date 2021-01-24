    public struct AgeGroup {
        public static readonly Baby = new AgeGroup(0, 7);
        public static readonly Child = new AgeGroup(7, 9);
    
        public AgeGroup(int fromInclusive, toExclusive) {
            this._fromInclusive = fromInclusive;
            this._toExclusive = toExclusive;
        }
    
        private int _fromInclusive, _toExclusive;
    }
