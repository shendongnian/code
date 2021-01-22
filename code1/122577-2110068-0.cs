    class PlayerPosition {
        public enum Position {
            Quarterback,
            Runningback,
            DefensiveEnd,
            Linebacker
        }
        public enum Type {
            Offense,
            Defense
        }
        public static Type GetTypeForPosition(Position position) {
            switch (position) {
                case Quarterback:
                case Runningback:
                    return Type.Offense;
                case DefensiveEnd:
                case Linebacker:
                    return Type.Defense;
            }
        }
    }
