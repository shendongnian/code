    public enum SportType
    {
        Soccer, Football, ...
    }
    public sealed class Foo
    {
        private static readonly IDictionary<SportType, Int32> sportTypeScoreMap =
            new Dictionary<SportType, Int32>
            {
                { Soccer, 30 },
                { Football, 20 },
                ...
            }
        private static readonly IDictionary<DayOfWeek, Int32> dayOfWeekScoreMap =
            new Dictionary<DayOfWeek, Int32>
            {
                { DayOfWeek.Monday, 12 },
                { DayOfWeek.Tuesday, 20 },
                ...
            }
        public Int32 GetScore(SportType sportType, DayOfWeek dayOfWeek)
        {
            return Foo.sportTypeScoreMap[sportType]
                 + Foo.dayOfWeekScoreMap[dayOfWeek];
        }
    }
